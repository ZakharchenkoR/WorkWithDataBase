using DAL.Context;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<Category> Category { get; }
        IRepository<Manufacturer> Manufacturer { get; }
        IRepository<Good> Good { get; }
        void Save();
    }
}
