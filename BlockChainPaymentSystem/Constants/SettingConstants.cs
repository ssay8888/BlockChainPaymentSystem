using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BlockChainPaymentSystem.Constants
{
    public static class SettingConstants
    {
        public const bool TestNet = true;

        public const string ApiKey = (TestNet ? "MGWF4DJ-QH9M7HN-N3ST9D3-NDR53SK" : "8RN5YAR-PPMM91Z-KPJB5B9-CDSBF5D");
        public const string ApiLink = (TestNet ? "https://api.sandbox.nowpayments.io/v1" : "https://api.nowpayments.io/v1");
        public const string IpnKey = (TestNet ? "GcWXQiyK+tuBKTOn3rEGFdWW1wVYqus0" : "");

        public const string DBString = "Server=tcp:sgblock.database.windows.net,1433;Initial Catalog=sgblock;Persist Security Info=False;User ID=sgadmin;Password=123456asdX;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public const string callBackUrl = "http://182.218.168.113:5454/Payment/PostCallBack";

        public static string MailId = "ssay8888", MailPassWord = "";

        public static string base_outcome_Coin = "xmr";

        private static Dictionary<string, string> tempCurrencies = new()
        { // 사용가능한 통화추가

            //{ "btc", "비트코인" },

            { "eth", "이더리움" },
            { "ltc", "라이트코인" },
            { "xmr", "모네르" },
            { "dash", "대시" },
            { "btg", "비트코인골드" },
            { "bch", "비트코인캐시" },
            { "qtum", "퀀텀" },
            { "xlm", "스텔라" },
            { "trx", "트론" },
            { "kmd", "코모도" },
            { "eos", "이오스" },
            { "waves", "웨이브" },
            { "ada", "에이다" },
        };
        private static Dictionary<string, string> realCurrencies = new();
        private static DateTime? LastAvailableTime = null;

        /// <summary>
        /// 사용할 통화중 사용불가능한 코인들은 거른다..
        /// 1분에 한번 업데이트한다.
        /// </summary>
        /// <returns></returns>
        public async static Task<Dictionary<string, string>> AvailableCurrencies()
        {
            var newTime = DateTime.Now;
            var oldtime = LastAvailableTime?.AddSeconds(60);
            if (oldtime == null || oldtime?.CompareTo(newTime) == -1)
            {
                LastAvailableTime = DateTime.Now;
                realCurrencies = new Dictionary<string, string>(tempCurrencies);
                if (TestNet)
                {
                    var c = await PaymentMethod.GetCurrencies();
                    foreach (var a in tempCurrencies)
                    {
                        bool check = false;
                        foreach (var b in c.Item1.currencies)
                        {
                            if (a.Key.Equals(b))
                            {
                                check = true;
                                break;
                            }
                        }
                        if (!check)
                        {
                            realCurrencies.Remove(a.Key);
                        }
                    }
                    return realCurrencies;
                } else
                {
                    var c = await PaymentMethod.GetCurrenciesFixRate();
                    foreach (var a in tempCurrencies)
                    {
                        bool check = false;
                        foreach (var b in c.Item1.currencies)
                        {
                            if (a.Key.Equals(b.currency))
                            {
                                check = true;
                                break;
                            }
                        }
                        if (!check)
                        {
                            realCurrencies.Remove(a.Key);
                        }
                    }
                    return realCurrencies;
                }
            }
            return realCurrencies;
        }
    }
}
