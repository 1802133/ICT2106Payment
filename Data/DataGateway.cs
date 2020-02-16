using ICT2106Payment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICT2106Payment.Data
{
    public class DataGateway<T> : IDataGateway<T> where T : class
    {
        internal ICT2106PaymentContext db;
        internal DbSet<T> data = null;

        public DataGateway(ICT2106PaymentContext db)
        {
            this.db = db;
            this.data = db.Set<T>();
        }

        public T Delete(string id)
        {
            T t = data.Find(id);
            data.Remove(t);
            return t;
        }

        public void Insert(T t)
        {
            data.Add(t);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public IEnumerable<T> SelectAll()
        {
            return data;
        }

        public T SelectById(string id)
        {
            return data.Find(id);
        }

        public void Update(T t)
        {
            data.Update(t);
        }
    }
}