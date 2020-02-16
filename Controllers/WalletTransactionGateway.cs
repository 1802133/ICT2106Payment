using _2106PaymentModule.Models;
using ICT2106Payment.Data;
using ICT2106Payment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICT2106Payment.Controllers
{
    public class WalletTransactionGateway : IWalletTransactionGateway
    {
        internal WalletContext db = new WalletContext();

        public void Insert(WalletTransaction wallet)
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

        public IEnumerable<WalletTransaction> SelectByAll()
        {
            //return db.WalletTransaction;
            throw new NotImplementedException();
        }

        public Wallet SelectById(string id)
        {
            //Wallet wallet = db.WalletTransaction.Find(id);
            //return wallet;
            throw new NotImplementedException();
        }

        public void Update(WalletTransaction wallet)
        {
            //db.WalletTransaction.Update(wallet);
            //db.SaveChanges();
            throw new NotImplementedException();
        }
    }
}
