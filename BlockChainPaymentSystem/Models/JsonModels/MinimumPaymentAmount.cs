using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChainPaymentSystem.Models.JsonModels
{
    public class MinimumPaymentAmount
    {
        public string currency_from { get; set; }
        public string currency_to { get; set; }
        public double min_amount { get; set; }
    }
}
