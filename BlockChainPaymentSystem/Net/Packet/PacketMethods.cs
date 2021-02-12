using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BlockChainPaymentSystem.Net.Packet
{
    public static class PacketMethods
    {
        public static readonly Dictionary<Type, Func<BinaryReader, object>> DecodeMethods = new Dictionary<Type, Func<BinaryReader, object>>
        {
            {typeof(byte), packet => packet.ReadByte() },
            {typeof(sbyte), packet => packet.ReadSByte() },
            {typeof(bool), packet => packet.ReadBoolean() },
            {typeof(short), packet => packet.ReadInt16() },
            {typeof(ushort), packet => packet.ReadUInt16() },
            {typeof(int), packet => packet.ReadInt32() },
            {typeof(uint), packet => packet.ReadUInt32() },
            {typeof(long), packet => packet.ReadInt64() },
            {typeof(ulong), packet => packet.ReadUInt64() },
            {typeof(float), packet => packet.ReadSingle() },
            {typeof(double), packet => packet.ReadDouble() },
            {typeof(string), packet =>
            {
                var count = packet.ReadInt16();
                return Encoding.UTF8.GetString(packet.ReadBytes(count));
            } }
        };

        public static readonly Dictionary<Type, Action<BinaryWriter, object>> EncodeMethods =
            new Dictionary<Type, Action<BinaryWriter, object>>
            {
                {typeof(byte), (packet, value) =>  packet.Write((byte) value)},
                {typeof(sbyte), (packet, value) =>  packet.Write((sbyte) value)},
                {typeof(bool), (packet, value) =>  packet.Write((bool) value)},
                {typeof(short), (packet, value) =>  packet.Write((short) value)},
                {typeof(ushort), (packet, value) =>  packet.Write((ushort) value)},
                {typeof(int), (packet, value) =>  packet.Write((int) value)},
                {typeof(uint), (packet, value) =>  packet.Write((uint) value)},
                {typeof(long), (packet, value) =>  packet.Write((long) value)},
                {typeof(ulong), (packet, value) =>  packet.Write((ulong) value)},
                {typeof(float), (packet, value) =>  packet.Write((float) value)},
                {typeof(double), (packet, value) =>  packet.Write((double) value)},
                {typeof(string), (packet, value) =>
                {
                    var data = Encoding.UTF8.GetBytes((string) value);
                    packet.Write((short)data.Length);
                    packet.Write(data);
                }},
            };
    }
}
