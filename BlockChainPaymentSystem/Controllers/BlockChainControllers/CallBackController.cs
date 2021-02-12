using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using BlockChainPaymentSystem.Constants;
using BlockChainPaymentSystem.Models.JsonModels;
using BlockChainPaymentSystem.Net;
using System.Threading.Tasks;

namespace BlockChainPaymentSystem.Controllers
{
    [Route("/Payment")]
    public class CallBackController : Controller
    {
        [HttpPost]
        [Route(""), Route("PostCallBack")]
        public async Task<IActionResult> CallBack([FromBody]ResponsePaymentModel name)
        {
            var asd = Request.Headers["X-NOWPayments-Sig"];
            var json = JsonConvert.SerializeObject(name);
            Client.Instance.Send(await PacketCreator.SendChargeResultAsync(name));
            //SettingConstants.NaverMail("", json);
            return Json(true);
        }
    }
}
