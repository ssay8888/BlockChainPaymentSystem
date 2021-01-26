using BlockChainPaymentSystem.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChainPaymentSystem.DataBase
{
    public static class Connection
    {
        public static ResponsePaymentModelContext GetResponseConnection()
        {
            var contextOptions = new DbContextOptionsBuilder<ResponsePaymentModelContext>()
                                    .UseSqlServer(Constants.SettingConstants.DBString)
                                    .Options;
            var db = new ResponsePaymentModelContext(contextOptions);
            return db;
        }
        public static RequestPaymentModelContext GetRequestConnection()
        {
            var contextOptions = new DbContextOptionsBuilder<RequestPaymentModelContext>()
                                    .UseSqlServer(Constants.SettingConstants.DBString)
                                    .Options;
            var db = new RequestPaymentModelContext(contextOptions);
            return db;
        }
    }
}
