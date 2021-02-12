using System;
using System.IO;
using System.Text;

namespace BlockChainPaymentSystem.Net.Packet
{
    public abstract class AbstractPacket : IDisposable
    {
        protected MemoryStream Stream;

        public int Length => (int)Stream.Length;
        public byte[] Buffer => Stream.ToArray();
        public int Available => Length - Position;
        public int Position
        {
            get => (int)Stream.Position;
            set => Stream.Position = value;
        }


        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var b in Buffer)
            {
                sb.AppendFormat("{0:X2} ", b);
            }

            return sb.ToString();
        }

        protected virtual void CustomDispose() { }

        public void Dispose()
        {
            CustomDispose();
            Stream.Dispose();
        }
    }
}