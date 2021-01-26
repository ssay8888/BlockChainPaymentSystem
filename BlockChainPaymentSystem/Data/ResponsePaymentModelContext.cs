using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlockChainPaymentSystem.Models.JsonModels;

namespace BlockChainPaymentSystem.Data
{
    public class ResponsePaymentModelContext : DbContext
    {
        public ResponsePaymentModelContext (DbContextOptions<ResponsePaymentModelContext> options)
            : base(options)
        {
        }

        public DbSet<BlockChainPaymentSystem.Models.JsonModels.ResponsePaymentModel> ResponsePaymentModel { get; set; }
    }
}
