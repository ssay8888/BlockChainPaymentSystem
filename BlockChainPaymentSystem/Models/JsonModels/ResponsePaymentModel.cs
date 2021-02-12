using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BlockChainPaymentSystem.Models.JsonModels
{
    public class ResponsePaymentModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int Id { get; set; }
        //생성된 결제 번호
        public string payment_id { get; set; }
        //결제 상태
        public string payment_status { get; set; }
        //입금할 주소
        public string pay_address { get; set; }
        //결제금액
        public double price_amount { get; set; }
        //통화
        public string price_currency { get; set; }
        //입금해야할 금액
        public double pay_amount { get; set; }
        //입금해야할 통화(btc, xmr) 등
        public string pay_currency { get; set; }
        //actually_paid
        public double actually_paid { get; set; } = 0;
        //상품 번호.
        public string order_id { get; set; }
        //상품 설명
        public string order_description { get; set; }
        //
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string payin_extra_id { get; set; } = null;
        //콜백 받을 url
        public string ipn_callback_url { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string purchase_id { get; set; }
        public double outcome_amount { get; set; } = 0;
        public string outcome_currency { get; set; } = "";
    }
}
