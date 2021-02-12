using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace BlockChainPaymentSystem.Constants.CultureCommon
{
    public static class CultureStorage
    {
        public static ConcurrentDictionary<int, CultureCoupon> cultures = new();

        private static ChromeDriverService _driverService = ChromeDriverService.CreateDefaultService();
        private static ChromeOptions _options = new ChromeOptions();
        private static ChromeDriver _driver = null;
        private static byte keyBoardType = 0; // 0 소문자상태 1 상태
        private static bool specialkeyBoardType = false; // false 소문자 또는  true 특수문자상태
        private static Dictionary<string, KeyPad> PwkeyStorage = new Dictionary<string, KeyPad>();
        public static int keyId = 0;

        private static string[] talkBackLowerText = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0",
            "q", "w", "e", "r", "t", "y", "u", "i", "o", "p", "a", "s", "d", "f", "g", "h", "j",
            "k", "l", "z", "x", "c", "v", "b", "n", "m" };
        private static string[] talkBackUpperText = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0",
            "Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P", "A", "S", "D", "F", "G", "H", "J",
            "K", "L", "Z", "X", "C", "V", "B", "N", "M" };
        private static string[] talkBackSpecialText = { "`", "~", "!", "@", "#",
            "$", "%", "^", "&", "*", "(", ")", "-",
            "_", "=", "+", "[", "{", "]", "}",
            "\\", "|", ";", ":", "/", "?", ",", "<",
            ".", ">", "'", "\"", "+", "-", "*", "/" };
        private static string[] talkBackNumberText = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };


        public static void ChargeTask()
        {
            keyId = new Random().Next(0, int.MaxValue);
            _driverService.HideCommandPromptWindow = true;
            //_options.AddArgument("disable-gpu");
            //_options.AddArgument("--headless");
            Thread thread = new Thread(() =>
            {
                while (true)
                {
                    foreach (CultureCoupon item in CultureStorage.cultures.Values.Where(n => !n.IsChecked))
                    {
                        if (!item.IsChecked)
                        {
                            ChargePinNumber(item.Id, item.PinNumber.Split("-"));
                        }
                    }
                    Thread.Sleep(5000);
                }
            });
            thread.Start();
        }

        private static bool CheckLogin()
        {
            Console.WriteLine("[Log] 로그인 체크 중...");
            if (_driver == null) _driver = new ChromeDriver(_driverService, _options);
            _driver.Navigate().GoToUrl("https://m.cultureland.co.kr/");
            try
            {
                var logoutButton = _driver.FindElementByXPath("//*[@id='logOutBtn']");
                Console.WriteLine("[Log] 로그인 세션 확인 성공");
                return true;
            }
            catch
            {
                Console.WriteLine("[Log] 로그인 세션 확인 실패");
                return false;
            }
        }

        private static bool TryLogin()
        {
            if (_driver == null) _driver = new ChromeDriver(_driverService, _options);
            _driver.Navigate().GoToUrl("https://m.cultureland.co.kr/mmb/loginMain.do");
            PwkeyStorage.Clear();
            var userId = _driver.FindElementByXPath("//*[@id='txtUserId']");
            userId.SendKeys("ssay1597");
            var userPw = _driver.FindElementByXPath("//*[@id='passwd']");
            userPw.Click();
            for (var i = 0; i < 5; i++)
            {
                for (var j = 1; j < (i == 3 ? 11 : i == 4 ? 3 : 12); j++)
                {
                    var xPath = $"//*[@id='mtk_passwd_Row{i}']/div[{j}]/div/img";
                    var pwRow = _driver.FindElementByXPath(xPath);
                    var attr = pwRow.GetAttribute("alt");
                    if (talkBackLowerText.Contains(attr))
                    {
                        var index = Array.FindIndex(talkBackLowerText, x => x == attr);
                        var keyCap = new KeyPad(xPath, attr, i, j);
                        if (!PwkeyStorage.ContainsKey(talkBackLowerText[index]))
                        {
                            PwkeyStorage.Add(talkBackLowerText[index], keyCap);
                        }
                        if (!PwkeyStorage.ContainsKey(talkBackUpperText[index]))
                        {
                            PwkeyStorage.Add(talkBackUpperText[index], keyCap);
                        }
                        if (!PwkeyStorage.ContainsKey(talkBackSpecialText[index]))
                        {
                            PwkeyStorage.Add(talkBackSpecialText[index], keyCap);
                        }
                    }
                }
            }
            var chars_ = "1597748x".ToCharArray();
            foreach (var char_ in chars_)
            {
                var str_ = char_.ToString();
                PwkeyStorage.TryGetValue(str_, out KeyPad key_);
                if (key_ == null) return false;
                if (char_ >= 48 & char_ <= 57) // 0~9
                {
                    if (specialkeyBoardType)
                    {
                        _driver.FindElementByXPath(SpecialButtonString()).Click();
                        specialkeyBoardType = false;
                    }
                }
                else if (char_ >= 97 & char_ <= 122) // a~z
                {
                    if (specialkeyBoardType)
                    {
                        _driver.FindElementByXPath(SpecialButtonString()).Click();
                        specialkeyBoardType = false;
                    }
                    if (keyBoardType == 1)
                    {
                        _driver.FindElementByXPath(ShiftButtonString()).Click();
                        keyBoardType = 0;
                    }
                }
                else if (char_ >= 65 & char_ <= 90)// A~Z
                {
                    if (specialkeyBoardType)
                    {
                        _driver.FindElementByXPath(SpecialButtonString()).Click();
                        specialkeyBoardType = false;
                    }
                    if (keyBoardType == 0)
                    {
                        _driver.FindElementByXPath(ShiftButtonString()).Click();
                        keyBoardType = 1;
                    }
                }
                else if ((char_ >= 33 & char_ <= 47) | (char_ >= 58 & char_ <= 64)
                      | (char_ >= 91 & char_ <= 96) | (char_ >= 123 & char_ <= 127))
                {
                    if (!specialkeyBoardType)
                    {
                        _driver.FindElementByXPath(SpecialButtonString()).Click();
                        specialkeyBoardType = true;
                    }
                }
                _driver.FindElementByXPath(key_.XPath).Click();
                Thread.Sleep(5);
            }

            if (chars_.Length < 12)
            {
                _driver.FindElementByXPath($"//*[@id='mtk_done']/div/img").Click();
            }

            _driver.FindElementByXPath($"//*[@id='btnLogin']").Click();

            Thread.Sleep(500);
            try
            {
                var logoutButton = _driver.FindElementByXPath("//*[@id='logOutBtn']");
                Console.WriteLine("[Log] 로그인 성공");
                return true;
            }
            catch
            {
                Console.WriteLine("[Log] 로그인 실패");
                return false;
            }
        }

        public static bool ChargePinNumber(int id, string[] Pins)
        {
            if (_driver == null) _driver = new ChromeDriver(_driverService, _options);
            while (true)
            {
                if (!CheckLogin())
                {
                    Console.WriteLine("[Log] 로그인 시도");
                    TryLogin();
                    continue;
                }
                break;
            }
            Dictionary<string, KeyPad> BackNumberStorage = new Dictionary<string, KeyPad>();
            _driver.Navigate().GoToUrl("https://m.cultureland.co.kr/csh/cshGiftCard.do");
            for (var i = 0; i < 3; i++) //1~3번째 핀번호
            {
                var pinText = _driver.FindElementByXPath($"//*[@id='txtScr{11 + i}']");
                pinText.SendKeys(Pins[i]);
            }

            for (var i = 0; i < 2; i++) //마지막핀번호는 쿼티키보드로 키보드 정렬
            {
                for (var j = 1; j <= 6; j++)
                {
                    var xPath = $"//*[@id='mtk_txtScr14_Row{i}']/div[{j}]/div/img";
                    var pwRow = _driver.FindElementByXPath(xPath);
                    var attr = pwRow.GetAttribute("alt");
                    if (talkBackNumberText.Contains(attr))
                    {
                        var index = Array.FindIndex(talkBackNumberText, x => x == attr);
                        var keyCap = new KeyPad(xPath, attr, i, j);
                        if (!BackNumberStorage.ContainsKey(talkBackNumberText[index]))
                        {
                            BackNumberStorage.Add(talkBackNumberText[index], keyCap);
                        }
                    }
                }
            }

            var lastPinNum = Pins[3].ToCharArray();
            foreach (var char_ in lastPinNum) // 마지막 핀번호 입력
            {
                var str_ = char_.ToString();
                BackNumberStorage.TryGetValue(str_, out KeyPad key_);
                if (key_ == null) return false;
                _driver.FindElementByXPath(key_.XPath).Click();
                Thread.Sleep(10);
            }


            try
            {
                _driver.FindElementByXPath($"//*[@id='mtk_done']/div/img").Click(); // 입력완료버튼이 살아있다면 누른다..
                //WriteLog("[성공] 핀번호 입력완료");
            }
            catch
            {
                //WriteLog("[무시] 핀번호 입력버튼 사라짐.");
            }


            _driver.FindElementByXPath($"//*[@id='btnCshFrom']").Click(); // 캐시충전
            Console.WriteLine("[Log] 캐시충전 시도");
            Thread.Sleep(3000);
            var pageSrc = _driver.PageSource;

            try
            {
                var pinResult_ = _driver.FindElementByXPath("//*[@id='wrap']/div[3]/section/div/table/tbody/tr/td[2]");//핀번호 테이블
                var amountResult_ = _driver.FindElementByXPath("//*[@id='wrap']/div[3]/section/dl/dd");//금액테이블


                if (pageSrc.Contains("상품권번호가 잘못 입력되었습니다."))
                {
                    Console.WriteLine("[Log] 핀 코드 에러 충전 실패");
                    ChangeCheckType(id, 0, true);
                    return false;
                }
                else
                {
                    Console.WriteLine($"[Log] 캐시충전 성공 {amountResult_.Text}");
                    return ChangeCheckType(id, Int32.Parse(amountResult_.Text.Replace(",", "").Replace("원", "")),  true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[Log] 알 수 없는 오류로인한 충전 실패");
                ChangeCheckType(id, 0, true);
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private static string ShiftButtonString()
        {
            return "//*[@id='mtk_cp']/div/img";
        }

        private static string SpecialButtonString()
        {
            return "//*[@id='mtk_sp']/div/img";
        }

        private static bool ChangeCheckType(int id, int amount, bool type)
        {
            var check = false;
            foreach (CultureCoupon item in CultureStorage.cultures.Values)
            {
                if (item.Id == id)
                {
                    item.Amount = amount;
                    item.IsChecked = type;
                    //Program.client_.SendAsync(PacketCreator.CouponResult(id, int.Parse(item.AccId.Text), byte.Parse(type), amount));
                    check = true;
                }
            }
            return check;
        }
    }
}
