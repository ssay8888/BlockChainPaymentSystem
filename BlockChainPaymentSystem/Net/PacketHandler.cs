using BlockChainPaymentSystem.Net.Packet.Header;

namespace BlockChainPaymentSystem.Net
{
    internal class PacketHandler : System.Attribute
    {
        public ServerHeader Header { get; }

        public PacketHandler(ServerHeader header) => Header = header;
    }
}
