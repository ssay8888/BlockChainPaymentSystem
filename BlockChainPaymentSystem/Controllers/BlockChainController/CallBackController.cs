using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using BlockChainPaymentSystem.Constants;
using BlockChainPaymentSystem.Models.JsonModels;

namespace BlockChainPaymentSystem.Controllers
{
    [Route("/Payment")]
    public class CallBackController : Controller
    {
        [HttpGet]
        [Route(""), Route("GetCallBack")]
        public IActionResult CallBack()
        {
            return View();
        }

        [HttpPost]
        [Route(""), Route("PostCallBack")]
        public IActionResult CallBack([FromBody]ResponsePaymentModel name)
        {
            var asd = Request.Headers["X-NOWPayments-Sig"];
            var json = JsonConvert.SerializeObject(name);

            //SettingConstants.NaverMail("", json);
            return Json(true);
        }
    }
}
