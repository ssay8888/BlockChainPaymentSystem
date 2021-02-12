using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BlockChainPaymentSystem.Models.JsonModels
{
    public class RequestPaymentModel
    {
        /// <summary>
        /// 결제 요청할 Model
        /// </summary>

        [Key]
        public int Id { get; set; }
        //지불해야할 금액 (필수)
        public double price_amount { get; set; }
        //통화 (필수)
        public string price_currency { get; set; } = "usd";
        //사용자가 지불해야하는 금액(선택) 하지않을경우 price_amount으로 설정됨
        public double? pay_amount { get; set; } = null;
        //pay_amount 가 지정된 통화(btc, eth 등).
        public string pay_currency { get; set; }
        //판매하는 식별 ID (선택)
        public string order_id { get; set; }
        //판매하는 상품의 정보 
        public string order_description { get; set; }
        //입금됐을때 받을 콜백 URL (선택)
        public string ipn_callback_url { get; set; }
        //고정환율교환(선택)
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool fixed_rate { get; set; } = false;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Case { get; set; }
    }
}
