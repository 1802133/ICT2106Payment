using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ICT2106Payment.Models;
using _2106PaymentModule.Models;
using ICT2106Payment.Controllers;

namespace ICT2106Payment.Data
{
    public class PaymentsController : Controller
    {
        internal PaymentGateway pdb;
        internal WalletGateway wdb;
        internal WalletTransactionGateway wtdb;

        public PaymentsController(ICT2106PaymentContext context)
        {
            this.pdb = new PaymentGateway(context);
            this.wdb = new WalletGateway(context);
            this.wtdb = new WalletTransactionGateway(context);
        }

        // GET: Payments
        public IActionResult Index()
        {
            return View(pdb.SelectAll());
        }

        // GET: Payments/Details/5
        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = pdb.SelectById(id);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // GET: Payments/Create
        public IActionResult Create(string bookingId, decimal totalAmount)
        {
            Payment payment = new Payment();
            payment.bookingId = bookingId;
            payment.totalAmount = totalAmount;
            return View(payment);
        }

        // POST: Payments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("paymentId,userId,paymentType,paymentDate,totalAmount,bookingId")] Payment payment)
        {
            /*
             * detect when user clicks pay by paypal or ewallet
             * if ewallet, perfrom checks to see if user has enough balance
             * if yes deduct value and save information
             * */
            if (ModelState.IsValid)
            {
                if (payment.paymentType == "Wallet")
                {
                    IEnumerable<Wallet> wallets = wdb.SelectAll();
                    foreach (var wallet in wallets)
                    {
                        if (wallet.userId == payment.userId)
                        {
                            if (CheckSufficientAmount(wallet, payment.totalAmount))
                            {
                                pdb.Insert(payment);
                                pdb.Save();
                                wallet.walletAmount -= payment.totalAmount;
                                wdb.Update(wallet);
                                wdb.Save();
                                WalletTransaction walletTransaction = new WalletTransaction();
                                walletTransaction.walletId = wallet.walletId;
                                walletTransaction.transactionType = "Payment";
                                walletTransaction.transactionDate = DateTime.Now;
                                walletTransaction.transactionAmount = payment.totalAmount;
                                wtdb.Insert(walletTransaction);
                                wtdb.Save();

                                return RedirectToAction(nameof(Index));
                            }
                            else
                            {
                                //TODO implement call to topup wallet with error message informing the user
                                //need to test with variables
                                return View("Create", "WalletTransactions");
                            }
                        }
                    }
                }
                else if (payment.paymentType == "Paypal")
                {
                    //TODO implement paypal here
                }
                
            }
            return View(payment);
        }

        // GET: Payments/Edit/5
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = pdb.SelectById(id);
            if (payment == null)
            {
                return NotFound();
            }
            return View(payment);
        }

        // POST: Payments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, [Bind("paymentId,userId,paymentType,paymentDate,totalAmount,bookingId")] Payment payment)
        {
            if (id != payment.paymentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    pdb.Update(payment);
                    pdb.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentExists(payment.paymentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(payment);
        }

        // GET: Payments/Delete/5
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = pdb.SelectById(id);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            var payment = pdb.SelectById(id);
            pdb.Delete(id);
            pdb.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentExists(string id)
        {
            if (pdb.SelectById(id) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool CheckSufficientAmount(Wallet wallet, decimal totalAmount)
        {   //implement check whether wallet has enough money
            /*
             * retrieve walletamount from DB
             * check wallet between the two
             * return true if sufficient
             * false if insufficient
             */
            if (wallet.walletAmount < totalAmount)
            {
                return false;
            }
            return true;
        }
    }
}
