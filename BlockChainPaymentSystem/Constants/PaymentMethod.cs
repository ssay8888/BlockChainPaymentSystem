using BlockChainPaymentSystem.Models.JsonModels;
using BlockChainPaymentSystem.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BlockChainPaymentSystem.Constants
{
    public static class PaymentMethod
    {
        /// <summary>
        /// Api상태를 리턴합니다.
        /// </summary>
        /// <returns></returns>
        public static async Task<ApiStatusModel> GetStatus()
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), $"{SettingConstants.ApiLink}/status"))
                {
                    var response = await httpClient.SendAsync(request);
                    var data = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ApiStatusModel>(data);
                }
            }
        }
        /// <summary>
        /// 사용가능한 통화를 얻습니다.
        /// </summary>
        public static async Task<(AvailableCurrenciesModelFix, string)> GetCurrenciesFixRate()
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), $"{SettingConstants.ApiLink}/currencies?fixed_rate=true"))
                {
                    request.Headers.TryAddWithoutValidation("x-api-key", SettingConstants.ApiKey);

                    var response = await httpClient.SendAsync(request);
                    var data = await response.Content.ReadAsStringAsync();
                    return (JsonConvert.DeserializeObject<AvailableCurrenciesModelFix>(data), data);
                }
            }
        }

        public static async Task<(AvailableCurrenciesModel, string)> GetCurrencies()
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), $"{SettingConstants.ApiLink}/currencies"))
                {
                    request.Headers.TryAddWithoutValidation("x-api-key", SettingConstants.ApiKey);

                    var response = await httpClient.SendAsync(request);
                    var data = await response.Content.ReadAsStringAsync();
                    return (JsonConvert.DeserializeObject<AvailableCurrenciesModel>(data), data);
                }
            }
        }
        /// <summary>
        /// 결제 ID의 거래 상태를 확인합니다.
        /// </summary>
        /// <param name="paymentid">결제 ID</param>
        public static async Task<ResponsePaymentModel> GetPaymentStatus(string paymentid)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("GET"), $"{SettingConstants.ApiLink}/payment/{paymentid}"))
                    {
                        request.Headers.TryAddWithoutValidation("x-api-key", SettingConstants.ApiKey);

                        var response = await httpClient.SendAsync(request);
                        var data = await response.Content.ReadAsStringAsync();
                        if (data.Contains("Payment not found"))
                        {
                            return null;
                        }
                        return JsonConvert.DeserializeObject<ResponsePaymentModel>(data);
                    }
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }
        /// <summary>
        /// 통화 기준 예상 가격을 뽑아냅니다.
        /// </summary>
        /// <param name="amount">금액</param>
        /// <param name="currency_from">기준 통화종류 ex usd btc 등.</param>
        /// <param name="currency_to">계산할 통화</param>
        /// <returns></returns>
        public static async Task<EstimatedPriceModel> GetEstimatedPrice(double amount, string currency_from, string currency_to)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), $"{SettingConstants.ApiLink}/estimate?amount={amount}&currency_from={currency_from}&currency_to={currency_to}"))
                {
                    request.Headers.TryAddWithoutValidation("x-api-key", SettingConstants.ApiKey);

                    var response = await httpClient.SendAsync(request);
                    var data = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<EstimatedPriceModel>(data);
                }
            }
        }
        /// <summary>
        /// 결제코드를 생성합니다.
        /// </summary>
        /// <param name="model">CreatePaymentModel</param>
        /// <returns></returns>
        public static async Task<ResponsePaymentModel> CreatePayment(RequestPaymentModel model)
        {
            var real = await SettingConstants.AvailableCurrencies();
            if (!real.ContainsKey(model.pay_currency)) return null;

            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("POST"), $"{SettingConstants.ApiLink}/payment"))
                    {
                        request.Headers.TryAddWithoutValidation("x-api-key", SettingConstants.ApiKey);
                        var _json = JsonConvert.SerializeObject(model, new JsonSerializerSettings
                        {
                            ContractResolver = new CamelCasePropertyNamesContractResolver(),
                            NullValueHandling = NullValueHandling.Ignore
                        });
                        request.Content = new StringContent(_json);
                        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                        var response = await httpClient.SendAsync(request);
                        var dataString = await response.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<ResponsePaymentModel>(dataString);
                        Client.Instance.Send(await PacketCreator.SendChargeResultAsync(data));
                        return data;
                    }
                }
            } catch
            {
                return null;
            }
        }
        /// <summary>
        /// 최소 결제 금액 받기
        /// </summary>
        /// <param name="currency_from">usd btc 등 기준으로</param>
        /// <param name="currency_to">xmr 의 최소 입금 금액</param>
        /// <returns></returns>
        public static async Task<MinimumPaymentAmount> GetMinimumPaymentAmount(string currency_from, string currency_to)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), $"{SettingConstants.ApiLink}/min-amount?currency_from={currency_from}&currency_to={currency_to}"))
                {
                    request.Headers.TryAddWithoutValidation("x-api-key", SettingConstants.ApiKey);

                    var response = await httpClient.SendAsync(request);
                    var data = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<MinimumPaymentAmount>(data);
                }
            }
        }
        /// <summary>
        /// 결제 목록을 가져옵니다.
        /// 테스트에서는 되지않는다.
        /// </summary>
        /// <param name="limit">1-500 까지 가능</param>
        /// <param name="page">0에서 -1까지 가능</param>
        /// <returns></returns>
        public static async Task<PaymentsListModel> GetPaymentsList(int limit, int page)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), $"{SettingConstants.ApiLink}/payment/?limit={limit}&page={page}"))
                {
                    request.Headers.TryAddWithoutValidation("x-api-key", SettingConstants.ApiKey);

                    var response = await httpClient.SendAsync(request);
                    var data = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<PaymentsListModel>(data);
                }
            }
        }
        /// <summary>
        /// 송장을 생성합니다.
        /// 안쓸거같다..
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static async Task<ResponsePaymentModel> CreateInvoice(RequestPaymentModel model)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), $"{SettingConstants.ApiLink}/invoice"))
                {
                    request.Headers.TryAddWithoutValidation("x-api-key", SettingConstants.ApiKey);

                    request.Content = new StringContent("{\n  \"price_amount\": 1000,\n  \"price_currency\": \"usd\",\n  \"order_id\": \"RGDBP-21314\",\n  \"order_description\": \"Apple Macbook Pro 2019 x 1\",\n  \"ipn_callback_url\": \"https://nowpayments.io\",\n  \"success_url\": \"https://nowpayments.io\",\n  \"cancel_url\": \"https://nowpayments.io\"\n}\n\n");
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

                    var response = await httpClient.SendAsync(request);
                }
            }
            return null;
        }
    }
}
