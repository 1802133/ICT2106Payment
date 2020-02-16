using _2106PaymentModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICT2106Payment.Data
{
    interface IWalletGateway
    {
        IEnumerable<Wallet> SelectByAll();

        Wallet SelectById(string id);

        void Insert(Wallet wallet);

        void Update(Wallet wallet);

        void Save();
    }
}
