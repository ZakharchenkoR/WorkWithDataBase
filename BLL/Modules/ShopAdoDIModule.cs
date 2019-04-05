using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models.CategoryDTO;
using BLL.Models.GoodDTO;
using BLL.Models.ManufacturerDTO;
using BLL.Services;
using DAL.Context;
using DAL.Repositories;
using DAL.UnitOfWork;
using Ninject.Modules;

namespace BLL.Modules
{
    public class ShopAdoDIModule :NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<Good>>().To<GoodRepository>();
            Bind<IService<GoodDTO>>().To<GoodService>();
            Bind<IRepository<Manufacturer>>().To<ManufacturerRepository>();
            Bind<IService<ManufacturerDTO>>().To<ManufacturerService>();
            Bind<IRepository<Category>>().To<CategoryRepositore>();
            Bind<IService<CategoryDTO>>().To<CategoryService>();
            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
