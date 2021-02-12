using BlockChainPaymentSystem.Net.Packet;
using BlockChainPaymentSystem.Net.Packet.Header;
using NetCoreServer;
using System;
using System.Threading;

namespace BlockChainPaymentSystem.Net
{
    internal class Client : TcpClient
    {
        internal static Client Instance => Lazy.Value;

        private static readonly Lazy<Client> Lazy = new(() => new Client());
        private bool stop;

        private Client() : base("127.0.0.1", 1597) => ConnectAsync();

        internal void DisconnectAndStop()
        {
            stop = true;
            DisconnectAsync();
            while (IsConnected)
                Thread.Yield();
            Environment.Exit(0);
        }

        internal new void Send(byte[] buffer)
        {
            if (stop) return;

            using var newPacket = new OutPacket(buffer.Length + 4);

            newPacket.Encode(buffer.Length);
            newPacket.EncodeBytes(buffer);

            SendAsync(newPacket.Buffer);
        }

        protected override void OnDisconnected()
        {
            //Constants.Logger.GetLogger().Warn($"BotClient {Id}가 연결 해제됨. 연결 재시도..");
            Thread.Sleep(1000);

            if (stop) return;

            ConnectAsync();
            //Constants.Logger.GetLogger().Info(IsConnected ? "BotClient 재연결 완료." : "BotClient 재연결 실패.");
        }

        protected override void OnReceived(byte[] buffer, long offset, long size)
        {
            if (size > 4)
            {
                Array.Resize(ref buffer, (int)size);
                using var inPacket = new InPacket(buffer);

                if (!(inPacket.PacketLen > 0 & inPacket.PacketLen == size - 4)) return;

                if (ServerPackets.GetHandler((ServerHeader)inPacket.Header, out var handler))
                {
                    handler.Handle(inPacket, this);
                }
                else
                {
                    //Constants.Logger.GetLogger().Error($"패킷 핸들러가 정의되지 않음. 패킷 Id: {inPacket.Header}");
                    DisconnectAndStop();
                }
            }
            else
            {
                //Constants.Logger.GetLogger().Error("패킷 헤더가 손상됨.");
                DisconnectAndStop();
            }
        }
    }
}
