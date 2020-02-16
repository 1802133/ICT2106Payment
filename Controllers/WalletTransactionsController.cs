using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ICT2106Payment.Models;
using _2106PaymentModule.Models;

namespace ICT2106Payment.Controllers
{
    public class WalletTransactionsController : Controller
    {
        internal WalletTransactionGateway wtdb;
        internal WalletGateway wdb;
        
        public WalletTransactionsController(ICT2106PaymentContext db)
        {
            this.wtdb = new WalletTransactionGateway(db);
            this.wdb = new WalletGateway(db);
        }
        // GET: WalletTransactions
        public ActionResult Index()
        {
            return View(wtdb.SelectAll());
        }

        // GET: WalletTransactions/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WalletTransaction walletTrans = wtdb.SelectById(id);

            if (walletTrans == null)
            {
                return NotFound();
            }

            return View(walletTrans);
        }

        // GET: WalletTransactions/Create
        public IActionResult Create(string id)
        {
            WalletTransaction walletTransaction = new WalletTransaction();
            walletTransaction.walletId = id;
            return View(walletTransaction);
        }

        // POST: WalletTransactions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("walletTransactionId,walletId,transactionType,transactionAmount,transactionDate")] WalletTransaction walletTransaction)
        {
            if (ModelState.IsValid)
            {
                Wallet wallet = wdb.SelectById(walletTransaction.walletId);
                if (walletTransaction.transactionType == "TopUp")
                {
                    wallet.walletAmount += walletTransaction.transactionAmount;

                }
                else if (walletTransaction.transactionType == "Deduct")
                {
                    wallet.walletAmount -= walletTransaction.transactionAmount;
                }
                wdb.Update(wallet);
                wdb.Save();
                wtdb.Insert(walletTransaction);
                wtdb.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(walletTransaction);
        }

        // GET: WalletTransactions/Edit/5
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WalletTransaction walletTrans = wtdb.SelectById(id);
            if (walletTrans == null)
            {
                return NotFound();
            }
            return View(walletTrans);
        }

        // POST: WalletTransactions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, [Bind("walletTransactionId,walletId,transactionType,transactionAmount,transactionDate")] WalletTransaction walletTransaction)
        {
            if (id != walletTransaction.walletTransactionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
              
                try
                {
                    wtdb.Update(walletTransaction);
                    wtdb.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WalletTransactionExists(walletTransaction.walletTransactionId))
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
            return View(walletTransaction);
        }

        private bool WalletTransactionExists(string id)
        {
            return (wtdb.SelectById(id) !=null);
        }
    }
}
