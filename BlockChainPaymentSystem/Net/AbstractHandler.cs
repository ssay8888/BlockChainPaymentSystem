using BlockChainPaymentSystem.Net.Packet;

namespace BlockChainPaymentSystem.Net
{
    internal abstract class AbstractHandler
    {
        public abstract void Handle(InPacket packet, Client c);
    }
}
