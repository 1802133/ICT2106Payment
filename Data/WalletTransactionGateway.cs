using _2106PaymentModule.Models;
using ICT2106Payment.Data;
using ICT2106Payment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICT2106Payment.Controllers
{
    public class WalletTransactionGateway : DataGateway<WalletTransaction>
    {
        public WalletTransactionGateway(ICT2106PaymentContext db) : base(db)
        {

        }
        
    }
}
