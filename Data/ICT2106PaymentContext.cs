using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using _2106PaymentModule.Models;

namespace ICT2106Payment.Models
{
    public class ICT2106PaymentContext : DbContext
    {

        public ICT2106PaymentContext (DbContextOptions<ICT2106PaymentContext> options)
            : base(options)
        {
        }

        public DbSet<_2106PaymentModule.Models.WalletTransaction> WalletTransaction { get; set; }

        public DbSet<_2106PaymentModule.Models.Wallet> Wallet { get; set; }

        public DbSet<_2106PaymentModule.Models.Payment> Payment { get; set; }
    }
}
