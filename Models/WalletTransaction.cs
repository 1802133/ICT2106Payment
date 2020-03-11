using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace _2106PaymentModule.Models
{
    public class WalletTransaction
    {
        public string walletTransactionId { get; set; }
        public string walletId { get; set; }
        public string transactionType { get; set; }
        public decimal transactionAmount { get; set; }
        public DateTime transactionDate { get; set; }
    }
}