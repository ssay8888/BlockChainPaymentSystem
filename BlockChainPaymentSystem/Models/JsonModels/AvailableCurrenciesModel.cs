using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChainPaymentSystem.Models.JsonModels
{
    public class AvailableCurrenciesModel
    {
        /// <summary>
        /// API를 이용한 사용가능한 목록을 가져옵니다.
        /// </summary>
        public string[] currencies { get; set; }
    }
}
