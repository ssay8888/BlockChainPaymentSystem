using BlockChainPaymentSystem.Models.JsonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChainPaymentSystem.Models.JsonModels
{
    public class PaymentsListModel
    {
        public List<ResponsePaymentModel> data { get; set; }
        public int limit { get; set; }
        public int page { get; set; }
        public int pagesCount { get; set; }
        public int total { get; set; }
    }
}
