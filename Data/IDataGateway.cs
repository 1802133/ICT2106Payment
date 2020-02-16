using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICT2106Payment.Data
{
    interface IDataGateway<T> where T : class
    {
        IEnumerable<T> SelectAll();
        T SelectById(string id);
        void Insert(T t);
        void Update(T t);
        T Delete(string id);
        void Save();
    }
}
