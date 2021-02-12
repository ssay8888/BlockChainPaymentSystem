using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BlockChainPaymentSystem.Net.Packet
{
    public class InPacket : AbstractPacket
    {
        private readonly BinaryReader Reader;
        public int PacketLen { get; private set; }
        public byte Header { get; private set; }

        public InPacket(byte[] buffer)
        {
            Stream = new MemoryStream(buffer, false);
            Reader = new BinaryReader(Stream, Encoding.UTF8);
            PacketLen = Decode<int>();
            Header = Decode<byte>();
        }

        public void Skip(int count) => Position += count;

        public T Decode<T>()
        {
            var type = typeof(T);
            if (PacketMethods.DecodeMethods.ContainsKey(type))
                return (T) PacketMethods.DecodeMethods[type](Reader);
            throw new NotSupportedException($"등록되지 않은 디코딩 타입입니다. 타입: {type}");
        }

        public IEnumerable<byte> Decode(int count) => Reader.ReadBytes(count);

        public IEnumerable<byte> ReadLeftoverBytes() => Decode(Available);

        protected override void CustomDispose() => Reader.Dispose();
    }
}
