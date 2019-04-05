using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Context;
using DAL.Repositories;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        ShopAdo db;

        IRepository<Category> category;
        IRepository<Manufacturer> manufacturer;
        IRepository<Good> good;

        public UnitOfWork()
        {
            db = new ShopAdo();
        }

        IRepository<Category> IUnitOfWork.Category => category = category ?? new CategoryRepositore(db);
        IRepository<Manufacturer> IUnitOfWork.Manufacturer => manufacturer = manufacturer ?? new ManufacturerRepository(db);
        IRepository<Good> IUnitOfWork.Good => good = good ?? new GoodRepository(db);

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
