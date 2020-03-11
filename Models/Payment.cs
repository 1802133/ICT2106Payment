using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2106PaymentModule.Models
{
    public class Payment
    {
        public string paymentId { get; set; }
        public string userId { get; set; }
        public string paymentType { get; set; }
        public DateTime paymentDate { get; set; }
        public decimal totalAmount { get; set; }
        public string bookingId { get; set; }
    }
}