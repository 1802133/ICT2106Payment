using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2106PaymentModule.Models
{
    public class Wallet
    {
        public string walletId { get; set; }
        public string userId { get; set; }
        public decimal walletAmount { get; set; }
    }
}