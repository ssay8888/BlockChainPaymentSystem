using BlockChainPaymentSystem.Net.Packet.Header;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BlockChainPaymentSystem.Net.Packet
{
    internal static class ServerPackets
    {
        private static readonly Dictionary<ServerHeader, AbstractHandler> Packets = new();

        internal static int PacketCount => Packets.Count;

        internal static void RegisterPackets()
        {
            var handlers = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => System.Attribute.IsDefined(type, typeof(PacketHandler)))
                .ToDictionary(
                    type => ((PacketHandler)type.GetCustomAttributes(typeof(PacketHandler), true).FirstOrDefault())?.Header ?? ServerHeader.NullPacket,
                    type => (AbstractHandler)Activator.CreateInstance(type));

            foreach (var (key, value) in handlers)
            {
                if (Packets.ContainsKey(key)) return;

                if (key == ServerHeader.NullPacket)
                {
                    //Constants.Logger.GetExceptionLogger().Error($"패킷 핸들러가 NULL. type: {key}");
                    return;
                }

                Packets.Add(key, value);
            }
        }

        internal static bool GetHandler(ServerHeader header, out AbstractHandler packet) => Packets.TryGetValue(header, out packet);
    }
}
