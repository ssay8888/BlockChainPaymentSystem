using System;
using System.Net;
using System.Net.Mail;

namespace BlockChainPaymentSystem.Constants
{
    public static class SettingConstants
    {
        public const bool TestNet = true;

        public const string ApiKey = (TestNet ? "MGWF4DJ-QH9M7HN-N3ST9D3-NDR53SK" : "8RN5YAR-PPMM91Z-KPJB5B9-CDSBF5D");
        public const string ApiLink = (TestNet ? "https://api.sandbox.nowpayments.io/v1" : "https://api.nowpayments.io/v1");
        public const string IpnKey = (TestNet ? "GcWXQiyK+tuBKTOn3rEGFdWW1wVYqus0" : "");

        public const string DBString = "Server=tcp:sgblock.database.windows.net,1433;Initial Catalog=sgblock;Persist Security Info=False;User ID=sgadmin;Password=123456asdX;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public const string callBackUrl = "http://182.218.168.113:8484/Payment/PostCallBack";

        public static string MailId = "ssay8888", MailPassWord = "";

        public static void NaverMail(string paymentId, string callback)
        {
            string body = "Payment - " + paymentId + " - \nDetails:\n" + callback;
            MailMessage message = new MailMessage();
            message.From = new MailAddress("ssay8888@naver.com"); //ex : ooo@naver.com
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
                smtp.Credentials = new NetworkCredential(MailId, MailPassWord);
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
