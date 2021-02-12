using BlockChainPaymentSystem.Net.Packet.Header;
using System;
using System.IO;

namespace BlockChainPaymentSystem.Net.Packet
{
    public class OutPacket : AbstractPacket, IDisposable
    {
        private BinaryWriter Writer;
        public int PacketLen { get; set; }
        public byte Header { get; set; }
        public bool Disposed { get; }

        public OutPacket(int size = 64)
        {
            Stream = new MemoryStream(size);
            Writer = new BinaryWriter(Stream);
            Disposed = false;
        }

        public void Encode<T>(T value)
        {
            ThrowIfDisposed();

            var type = typeof(T);
            if (value == null) value = default;
            if(!PacketMethods.DecodeMethods.ContainsKey(type))
                throw new NotSupportedException($"등록되지 않은 인코딩 타입입니다. 타입: {type}");
            PacketMethods.EncodeMethods[type](Writer, value);
        }

        public void EncodeHeader(byte header)
        {
            Header = header;
            Encode(header);
        }

        public void EncodeBytes(byte[] data)
        {
            ThrowIfDisposed();
            foreach (var b in data) Encode(b);
        }

        public void WriteHexString(string value) => EncodeBytes(StringToByteArray(value));

        public static byte[] StringToByteArray(string hex)
        {
            var numberChars = hex.Length;
            var bytes = new byte[numberChars / 2];
            for (var i = 0; i < numberChars; i += 2)
                bytes[i / 2] = byte.Parse(hex.Substring(i, 2));
            return bytes;
        }

        private void ThrowIfDisposed()
        {
            if (Disposed)
            {
                throw new ObjectDisposedException(GetType().FullName);
            }
        }
    }
}
