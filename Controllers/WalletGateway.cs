using _2106PaymentModule.Models;
using ICT2106Payment.Data;
using ICT2106Payment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICT2106Payment.Controllers
{
    public class WalletGateway : IWalletGateway
    {
        internal WalletContext db = new WalletContext();

        public void Insert(Wallet wallet)
        {
            //db.WalletTransaction.Add(wallet);
            //db.SaveChanges();
            throw new NotImplementedException();
        }

        public void Save()
        {
            //db.SaveChanges();
            throw new NotImplementedException();
        }

        public IEnumerable<Wallet> SelectByAll()
        {
            return db.Wallet.ToList();
            throw new NotImplementedException();
        }

        public Wallet SelectById(string id)
        {
            Wallet wallet = db.Wallet.Find(id);
            return wallet;
            throw new NotImplementedException();
        }

        public void Update(Wallet wallet)
        {
            //db.WalletTransaction.Update(wallet);
            //db.SaveChanges();
            throw new NotImplementedException();
        }
    }
}
