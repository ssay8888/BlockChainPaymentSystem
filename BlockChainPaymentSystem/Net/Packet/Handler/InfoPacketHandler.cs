using BlockChainPaymentSystem.Constants.MapleInfoStorage;
using BlockChainPaymentSystem.Net.Packet.Header;
using System;
using System.Diagnostics;

namespace BlockChainPaymentSystem.Net.Packet.Handler
{
    [PacketHandler(ServerHeader.InfoPacket)]
    internal class InfoPacketHandler : AbstractHandler
    {
        public override void Handle(InPacket packet, Client c)
        {
            var info = new MapleInfo() {
                Id = packet.Decode<string>(),
                Cash = packet.Decode<int>(),
                LastUpdateTime = packet.Decode<long>(),
                Token = packet.Decode<string>()
            };
            MapleStorage.Storage.AddOrUpdate(info.Id, info, (k, v) => info);
            Debug.WriteLine($"{MapleStorage.Storage.Count}개 {info.LastUpdateTime}");
        }
    }
}
