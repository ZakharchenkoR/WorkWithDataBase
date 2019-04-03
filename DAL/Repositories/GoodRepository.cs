using DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    MessageBox.Show("Object: " + validationError.Entry.Entity.ToString());
                        foreach (DbValidationError err in validationError.ValidationErrors)
                        {
                            MessageBox.Show(err.ErrorMessage + "");
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void Update(Good item)
        {
            foreach (var i in db.Good)
            {
                if (i.GoodId == item.GoodId)
                {
                    i.GoodName = item.GoodName;
                    i.ManufacturerId = item.ManufacturerId;
                    i.CategoryId = item.CategoryId;
                    i.Price = item.Price;
                    i.GoodCount = item.GoodCount;
                    break;
                }
            }
        }

        ~GoodRepository()
        {
            db.Dispose();
        }
    }
}
