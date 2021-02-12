using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BlockChainPaymentSystem.Constants
{
    public static class PublicMethod
    {
        private static DateTime Jan1st1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static string ExchangeRate(double usd)
        {
            using (var wc = new WebClient())
            {
                var won = wc.DownloadString(new Uri($"https://search.naver.com/search.naver?sm=tab_hty.top&where=nexearch&query={usd}$"));
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(won);
                var asdf=  doc.DocumentNode.SelectSingleNode("//input[contains(@id, 'ds_to_money')]");
                return asdf.Attributes["value"].Value;
            }
        }

        public static long CurrentTimeMillis()
        {
            return (long)(DateTime.UtcNow - Jan1st1970).TotalMilliseconds;
        }

        public static void NaverMail(string paymentId, string callback)
        {
            string body = "Payment - " + paymentId + " - \nDetails:\n" + callback;
            MailMessage message = new MailMessage();
            message.From = new MailAddress($"{SettingConstants.MailId}@naver.com"); //ex : ooo@naver.com
            message.To.Add("ssay8888@naver.com"); //ex : ooo@gmail.com
            message.Subject = "&#44208;&#51228;&#50756;&#47308;";
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            message.Body = body;
            message.BodyEncoding = System.Text.Encoding.UTF8;

            try
            {
                SmtpClient smtp = new SmtpClient("smtp.naver.com", 587);
                smtp.UseDefaultCredentials = false; // 시스템에 설정된 인증 정보를 사용하지 않는다.
                smtp.EnableSsl = true;  // SSL을 사용한다.
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network; // 이걸 하지 않으면 naver 에 인증을 받지 못한다.
                smtp.Credentials = new NetworkCredential(SettingConstants.MailId, SettingConstants.MailPassWord);
                smtp.Send(message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("이메일 전송 실패");
            }
        }
    }
}
