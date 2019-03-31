using DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CategoryRepositore : IRepository<Category>
    {
        ShopAdo db = new ShopAdo();

        public void Add(Category item)
        {
            db.Category.Add(item);
        }

        public void Delete(Category item)
        {
            db.Category.Remove(item);
        }

        public Category Get(int id)
        {
            return db.Category.Find(id);
        }

        public IEnumerable<Category> GetAll()
        {
            return db.Category;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Category item)
        {
            throw new NotImplementedException();
        }
        
        ~CategoryRepositore()
        {
            db.Dispose();
        }
    }
}
