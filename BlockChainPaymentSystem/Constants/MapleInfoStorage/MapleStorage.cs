using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChainPaymentSystem.Constants.MapleInfoStorage
{
    public static class MapleStorage
    {
        public static ConcurrentDictionary<string, MapleInfo> Storage = new();

        public static MapleInfo GetValue(string key)
        {
            Storage.TryGetValue(key, out var value);
            return (PublicMethod.CurrentTimeMillis() > value?.LastUpdateTime + 1000 * 60 * 60 * 12) ? null : value;
        }
    }
}
