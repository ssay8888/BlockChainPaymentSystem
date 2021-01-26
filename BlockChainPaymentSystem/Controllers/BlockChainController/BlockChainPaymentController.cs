using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BlockChainPaymentSystem.Constants;
using BlockChainPaymentSystem.Models.JsonModels;
using Microsoft.EntityFrameworkCore;
using BlockChainPaymentSystem.DataBase;
using System.Collections.Generic;
using System;

namespace BlockChainPaymentSystem.Controllers.BlockChain
{
    [Route("/Payment")]
    public class BlockChainPaymentController : Controller
    {
        [Route(""), Route("Pay")]
        [HttpGet]
        public async Task<IActionResult> Payment()
        {
            return View();
        }

        [Route(""), Route("PayPost")]
        public async Task<ResponsePaymentModel> CreatePay(string purchase_id, string currency)
        {
            ResponsePaymentModel response = null;

            response = new ResponsePaymentModel()
            {
                pay_address = "sgdgsdasgdsdgsdgsdg" + new Random().Next(123456789)
            };
            return response;

            if (purchase_id == null | purchase_id == "")
            {
                purchase_id = "test_test1";
            }
            if (currency == null | currency == "")
            {
                currency = "btc";
            }
            using (var _rsdb = Connection.GetResponseConnection())
            {
                response = await _rsdb.ResponsePaymentModel
                    .FirstOrDefaultAsync(m => m.order_id == purchase_id);

                var create = new RequestPaymentModel()
                {
                    price_amount = 0.1,
                    price_currency = "xmr",
                    pay_currency = currency,
                    order_id = purchase_id,
                    order_description = "캐시충전 요청",
                    ipn_callback_url = SettingConstants.callBackUrl,
                    Case = "fail"
                };
                if (response == null)
                {
                    response = await PaymentMethod.CreatePayment(create);
                    _rsdb.Add(response);
                    await _rsdb.SaveChangesAsync();
                }
                else
                {
                    response = await PaymentMethod.GetPaymentStatus(response.payment_id);
                    switch (response.payment_status)
                    {
                        case "watiing":
                            {
                                break;
                            }
                        default:
                            {
                                _rsdb.Update(response);
                                await _rsdb.SaveChangesAsync();

                                response = await PaymentMethod.CreatePayment(create);
                                _rsdb.Add(response);
                                await _rsdb.SaveChangesAsync();
                                break;
                            }
                    }
                }
            }
            return response;
        }


        [Route(""), Route("exchangerate")]
        public async Task<EstimatedPriceModel> LoadExchangeRate(double amount, string currency_from, string currency_to)
        {
            var exchange = await PaymentMethod.GetEstimatedPrice(amount, currency_from, currency_to);
            return exchange;
        }
    }
}
