using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlockChainPaymentSystem.Models.JsonModels;

namespace BlockChainPaymentSystem.Data
{
    public class RequestPaymentModelContext : DbContext
    {
        public RequestPaymentModelContext (DbContextOptions<RequestPaymentModelContext> options)
            : base(options)
        {
        }

        public DbSet<BlockChainPaymentSystem.Models.JsonModels.RequestPaymentModel> RequestPaymentModel { get; set; }
    }
}
