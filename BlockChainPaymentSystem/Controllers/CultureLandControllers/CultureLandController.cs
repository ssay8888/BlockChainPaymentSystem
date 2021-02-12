using BlockChainPaymentSystem.Constants.CultureCommon;
using BlockChainPaymentSystem.Models.CultureModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlockChainPaymentSystem.Controllers.CultureLandController
{
    public class CultureLandController : Controller
    {
        [HttpGet]
        public IActionResult Index(int accid)
        {
            return View(new ChargeModel() { src10Id = CultureStorage.keyId++, src20Id = CultureStorage.keyId++, src30Id = CultureStorage.keyId++, src40Id = CultureStorage.keyId++, accid = accid });
        }

        [HttpPost]
        public IActionResult Charge(ChargeModel model)
        {
            if (model.src11?.Length == 4 && model.src12?.Length == 4 && model.src13?.Length == 4 && model.src14?.Length >= 4)
            {
                var newCoupon = new CultureCoupon()
                {
                    Id = model.src10Id,
                    AccId = model.accid,
                    PinNumber = model.src11 + "-" + model.src12 + "-" + model.src13 + "-" + model.src14
                };
                CultureStorage.cultures.TryAdd(newCoupon.Id, newCoupon);
                Console.WriteLine(newCoupon.PinNumber);
            }
            if (model.src21?.Length == 4 && model.src22?.Length == 4 && model.src23?.Length == 4 && model.src24?.Length >= 4)
            {
                var newCoupon = new CultureCoupon()
                {
                    Id = model.src20Id,
                    AccId = model.accid,
                    PinNumber = model.src21 + "-" + model.src22 + "-" + model.src23 + "-" + model.src24
                };
                CultureStorage.cultures.TryAdd(newCoupon.Id, newCoupon);
                Console.WriteLine(newCoupon.PinNumber);
            }
            if (model.src31?.Length == 4 && model.src32?.Length == 4 && model.src33?.Length == 4 && model.src34?.Length >= 4)
            {
                var newCoupon = new CultureCoupon()
                {
                    Id = model.src30Id,
                    AccId = model.accid,
                    PinNumber = model.src31 + "-" + model.src32 + "-" + model.src33 + "-" + model.src34
                };
                CultureStorage.cultures.TryAdd(newCoupon.Id, newCoupon);
                Console.WriteLine(newCoupon.PinNumber);
            }
            if (model.src41?.Length == 4 && model.src42?.Length == 4 && model.src43?.Length == 4 && model.src44?.Length >= 4)
            {
                var newCoupon = new CultureCoupon()
                {
                    Id = model.src40Id,
                    AccId = model.accid,
                    PinNumber = model.src41 + "-" + model.src42 + "-" + model.src43 + "-" + model.src44
                };
                CultureStorage.cultures.TryAdd(newCoupon.Id, newCoupon);
                Console.WriteLine(newCoupon.PinNumber);
            }
            return View(model);
        }
        

    }
}
