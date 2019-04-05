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
    public class CategoryRepositore : IRepository<Category>
    {
        ShopAdo db;

        public CategoryRepositore()
        {
            db = new ShopAdo();
        }

        public CategoryRepositore(ShopAdo db)
        {
            this.db = db;
        }

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

        public void Update(Category item)
        {
            foreach (var i in db.Category)
            {
                if(i.CategoryId == item.CategoryId)
                {
                    i.CategoryName = item.CategoryName;
                    db.Entry(i).State = EntityState.Modified;
                    break;
                }
            }
        }
        
        ~CategoryRepositore()
        {
            db.Dispose();
        }
    }
}
