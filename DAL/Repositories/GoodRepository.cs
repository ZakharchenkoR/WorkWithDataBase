using DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class GoodRepository : IRepository<Good>
    {
        ShopAdo db = new ShopAdo();
     
        public void Add(Good item)
        {
            db.Good.Add(item);
        }

        public void Delete(Good item)
        {
            db.Good.Remove(item);
        }

        public Good Get(int id)
        {
            return db.Good.Find(id);
        }

        public IEnumerable<Good> GetAll()
        {
            return db.Good;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Good item)
        {
            throw new NotImplementedException();
        }

        ~GoodRepository()
        {
            db.Dispose();
        }
    }
}
