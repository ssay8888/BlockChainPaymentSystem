using BlockChainPaymentSystem.Net.Packet.Header;
using System;
using System.Diagnostics;

namespace BlockChainPaymentSystem.Net.Packet.Handler
{
    [PacketHandler(ServerHeader.PingPacket)]
    internal class PingPacketHandler : AbstractHandler
    {
        public override void Handle(InPacket packet, Client c)
        {
            c.Send(PacketCreator.SendPong());
        }
    }
}
