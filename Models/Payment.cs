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

        //need to check what the user clicked.

        private void UpdatePaymentDetails(decimal totalAmount)
        {
            //Implement updatePaymentDetails
            //update paymentdetails in db
        }

        private void InsertPaymentDetails(string userId, int paymentDetailsId)
        {
            //Implement InsertPaymentDetails
            //insert paymentdetails to DB
        }
        private bool CheckSufficientAmount(string walletId, int totalAmount)
        {

            //implement check whether wallet has enough money
            /*
             * retrieve walletamount from DB
             * check wallet between the two
             * return true if sufficient
             * false if insufficient
             */
            return false;
        }
    }
}