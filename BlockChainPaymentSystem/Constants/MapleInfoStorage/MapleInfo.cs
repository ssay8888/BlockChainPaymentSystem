using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChainPaymentSystem.Constants.MapleInfoStorage
{
    public class MapleInfo
    {
        public string Id { get; set; }
        public int Cash { get; set; }
        public long LastUpdateTime { get; set; }
        public string Token { get; set; }
    }
}
