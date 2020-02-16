using _2106PaymentModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICT2106Payment.Data
{
    interface IWalletTransactionGateway
    {
        IEnumerable<WalletTransaction> SelectByAll();

        Wallet SelectById(string id);

        void Insert(WalletTransaction wallet);

        void Update(WalletTransaction wallet);

        void Save();

    }
}
