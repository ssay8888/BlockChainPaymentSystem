using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChainPaymentSystem.Models.JsonModels
{
    public class EstimatedPriceModel
    {
        /// <summary>
        /// 금액당 예상 가격을 확인하는 모델
        /// example: https://api.nowpayments.io/v1/estimate?amount=3999.5000&currency_from=usd&currency_to=btc
        /// </summary>
        public string currency_from { get; set; }
        public double amount_from { get; set; }
        public string currency_to { get; set; }
        public double estimated_amount { get; set; }

    }
}
