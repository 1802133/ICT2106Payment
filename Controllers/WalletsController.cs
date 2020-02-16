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
    public class WalletsController : Controller
    {
        internal WalletGateway wdb;

        // GET: Wallets
        public ActionResult Index()
        {
            return View(wdb.SelectAll());
        }

        // GET: Wallets/Details/5
        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Wallet wallet = wdb.SelectById(id);
            if (wallet == null)
            {
                return NotFound();
            }

            return View(wallet);
        }

        // GET: Wallets/Create
        public IActionResult Create(string id)
        {
            var wallet = wdb.SelectById(id);
            return View();
        }

        // POST: Wallets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("walletId,userId,walletAmount")] Wallet wallet)
        {
            if (ModelState.IsValid)
            {
                wdb.Insert(wallet);
                wdb.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(wallet);
        }

        // GET: Wallets/Edit/5
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Wallet wallet = wdb.SelectById(id);
            if (wallet == null)
            {
                return NotFound();
            }
            return View(wallet);
        }

        // POST: Wallets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, [Bind("walletId,userId,walletAmount")] Wallet wallet)
        {
            if (id != wallet.walletId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    wdb.Update(wallet);
                    wdb.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WalletExists(wallet.walletId))
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
            return View(wallet);
        }


        private bool WalletExists(string id)
        {
            return (wdb.SelectById(id) != null);
        }
    }
}
