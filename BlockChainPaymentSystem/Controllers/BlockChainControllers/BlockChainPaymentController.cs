using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BlockChainPaymentSystem.Constants;
using BlockChainPaymentSystem.Models.JsonModels;
using Microsoft.EntityFrameworkCore;
using BlockChainPaymentSystem.DataBase;
using System.Collections.Generic;
using System;
using BlockChainPaymentSystem.Net;

namespace BlockChainPaymentSystem.Controllers.BlockChain
{
    [Route("/Payment")]
    public class BlockChainPaymentController : Controller
    {
        [Route(""), Route("Pay")]
        [HttpGet]
        public IActionResult Payment(string id)
        {
            if (id == null || !id.Contains("_")) return new ContentResult() { Content = "비정상 접속" };
            string id_ = id.Split("_")[0], token = id.Split("_")[1];
            ViewBag.Id = id_;
            ViewBag.Token = token;
            var value = Constants.MapleInfoStorage.MapleStorage.GetValue(id_);
            if (!id_.Equals("123456"))
            {
                if (value == null || !value.Token.Equals(token))
                {
                    return new ContentResult() { Content = "비정상 접속" };
                }
            }
            return View();
        }
        [Route(""), Route("Cur")]
        public IActionResult GetCurrencies(string a)
        {
            if (SettingConstants.TestNet)
            {
                var dd = PaymentMethod.GetCurrencies().Result;
                return new ContentResult { Content = dd.Item2 };
            } else
            {
                var dd = PaymentMethod.GetCurrenciesFixRate().Result;
                return new ContentResult { Content = dd.Item2 };
            }
        }


        [Route("minimum")]
        public MinimumPaymentAmount GetMinimumPaymentAmount(string currency_from)
        {
            var minimum = PaymentMethod.GetMinimumPaymentAmount(currency_from, SettingConstants.base_outcome_Coin).Result;

            return minimum;
        }

        [Route(""), Route("PayPost")]
        public async Task<ResponsePaymentModel> CreatePay(string purchase_id, string currency, string token)
        {
            ResponsePaymentModel lastResponse = null;
            /*
            response = new ResponsePaymentModel()
            {
                pay_address = "sgdgsdasgdsdgsdgsdg" + new Random().Next(123456789)
            };*/
            //return response;

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
                var listResponse = await _rsdb.ResponsePaymentModel.ToListAsync();
                listResponse.Sort(delegate (ResponsePaymentModel c1, ResponsePaymentModel c2) { return c1.created_at.CompareTo(c2.created_at); });
                lastResponse = listResponse.FindLast(m => m.order_id == $"{purchase_id}_{token}"
                && m.pay_currency == currency
                && m.price_currency == SettingConstants.base_outcome_Coin);
                ResponsePaymentModel newResponse = null;

                //.FirstOrDefaultAsync(m => m.order_id == $"{purchase_id}_{token}" && m.pay_currency == currency);
                var minimum = await PaymentMethod.GetMinimumPaymentAmount(currency, SettingConstants.base_outcome_Coin);
                var minimum3 = await PaymentMethod.GetEstimatedPrice(minimum.min_amount, currency, SettingConstants.base_outcome_Coin);
                var create = new RequestPaymentModel()
                {
                    price_amount = minimum3.estimated_amount, //원래금액
                    price_currency = SettingConstants.base_outcome_Coin,
                    pay_amount = minimum.min_amount, //사용자가 지불해야할 금액
                    pay_currency = currency,
                    order_id = $"{purchase_id}_{token}",
                    order_description = "캐시충전 요청",
                    ipn_callback_url = SettingConstants.callBackUrl
                    //Case = "fail"
                };
                if (lastResponse == null)
                {
                    newResponse = await PaymentMethod.CreatePayment(create);
                    if (newResponse != null)
                    {
                        _rsdb.Add(newResponse);
                        await _rsdb.SaveChangesAsync();
                        return newResponse;
                    }
                }
                else
                {
                    ResponsePaymentModel loadResponse = await PaymentMethod.GetPaymentStatus(lastResponse.payment_id);
                    if (loadResponse == null)
                    {
                        newResponse = await PaymentMethod.CreatePayment(create);
                        if (newResponse != null)
                        {
                            _rsdb.Add(newResponse);
                            await _rsdb.SaveChangesAsync();
                            return newResponse;
                        }
                    }
                    switch (loadResponse.payment_status)
                    {
                        case "waiting":
                            {
                                return loadResponse;
                            }
                        default:
                            {
                                newResponse = await PaymentMethod.CreatePayment(create);
                                if (loadResponse.payment_status == null || !loadResponse.payment_status.Equals(lastResponse.payment_status))
                                {
                                    if (loadResponse != null)
                                    {
                                        _rsdb.Update(loadResponse);
                                        await _rsdb.SaveChangesAsync();
                                    }


                                    if (newResponse != null)
                                    {
                                        _rsdb.Add(newResponse);
                                        await _rsdb.SaveChangesAsync();
                                        return newResponse;
                                    }
                                } else
                                {
                                    if (newResponse != null)
                                    {
                                        _rsdb.Add(newResponse);
                                        await _rsdb.SaveChangesAsync();
                                        return newResponse;
                                    }
                                }
                                break;
                            }
                    }
                }
            }
            return null;
        }


        [Route(""), Route("exchangerate")]
        public async Task<double> LoadExchangeRate(double amount, string currency_from, string currency_to)
        {
            var exchange = await PaymentMethod.GetEstimatedPrice(amount, currency_from, currency_to);

            return exchange.estimated_amount;
        }




    }
}
