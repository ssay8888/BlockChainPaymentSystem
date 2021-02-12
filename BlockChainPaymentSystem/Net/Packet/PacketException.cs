using System;
using System.Net.Sockets;

namespace BlockChainPaymentSystem.Net.Packet
{
    public sealed class PacketException : Exception
    {
        public PacketException(string message) : base(message)
        {

        }
    }

    static class SocketExtensions
    {
        public static bool IsConnected(this Socket socket)
        {
            try
            {
                return !(socket.Poll(1, SelectMode.SelectRead) && socket.Available == 0);
            }
            catch (Exception) { return false; }
        }
    }
}
