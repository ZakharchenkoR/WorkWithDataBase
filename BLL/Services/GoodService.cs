using BLL.Services;
using DAL.Context;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BLL.Models.GoodDTO
{
    public class GoodService : IService<GoodDTO>
    {
        private IUnitOfWork unitOfWork;
        public GoodService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<GoodDTO> GetAll()
        {
            return unitOfWork.Good.GetAll()
                .Select(x => new GoodDTO
                {
                    Id = x.GoodId,
                    Name = x.GoodName,
                    ManufacturerId = x.ManufacturerId,
                    CategoryId = x.CategoryId,
                    ManufacturerName = x.Manufacturer?.ManufacturerName,
                    CategoryName = x.Category?.CategoryName,
                    Price = x.Price,
                    Count = x.GoodCount
                });
        }

        public void Remove(GoodDTO item)
        {
            try
            {
                unitOfWork.Good.Delete(unitOfWork.Good.Get(item.Id));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            unitOfWork.Save();
        }

        public void Add(GoodDTO item)
        {
            Good temp = new Good
            {
                GoodName = item.Name,
                ManufacturerId = item.ManufacturerId,
                CategoryId = item.CategoryId,
                Price = item.Price,
                GoodCount = item.Count
            };

            unitOfWork.Good.Add(temp);
            unitOfWork.Save();
        }

        public void Update(GoodDTO Item)
        {
            Good temp = new Good
            {
                GoodId = Item.Id,
                GoodName = Item.Name,
                ManufacturerId = Item.ManufacturerId,
                CategoryId = Item.CategoryId,
                Price = Item.Price,
                GoodCount = Item.Count
            };
            unitOfWork.Good.Update(temp);
            unitOfWork.Save();
        }
    }
}
