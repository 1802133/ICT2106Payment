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
        private WalletTransactionGateway walletTransactionGateway = new WalletTransactionGateway();
        private WalletGateway walletGateway = new WalletGateway();

        // GET: WalletTransactions
        public ActionResult Index()
        {
            return View(walletTransactionGateway.SelectByAll());
        }

        // GET: WalletTransactions/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Wallet walletTrans = walletTransactionGateway.SelectById(id);

            if (walletTrans == null)
            {
                return NotFound();
            }

            return View(walletTrans);
        }

        // GET: WalletTransactions/Create
        public IActionResult Create(string id)
        {
            var wallet = walletTransactionGateway.SelectById(id);
            return View(wallet);
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
                walletTransactionGateway.Insert(walletTransaction);
                walletTransactionGateway.Save();
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

            Wallet walletTrans = walletTransactionGateway.SelectById(id);
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
                    walletTransactionGateway.Update(walletTransaction);
                    walletTransactionGateway.Save();
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
            return (walletTransactionGateway.SelectById(id) !=null);
        }
    }
}
