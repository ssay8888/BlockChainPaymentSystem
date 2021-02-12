using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChainPaymentSystem.Models.JsonModels
{
    public class AvailableCurrenciesModelFix
    {
        /// <summary>
        /// API를 이용한 사용가능한 목록을 가져옵니다.
        /// </summary>
        public AvailableCurrenciesFixedRateModel[] currencies { get; set; }
    }
    public class AvailableCurrenciesModel
    {
        /// <summary>
        /// API를 이용한 사용가능한 목록을 가져옵니다.
        /// </summary>
        public string[] currencies { get; set; }
    }

    public class AvailableCurrenciesFixedRateModel
    {
        public double min_amount { get; set; }
        public double max_amount { get; set; }
        public string currency { get; set; }

    }
}
