using BLL.Services;
using DAL.Context;
using DAL.Repositories;
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
        private IRepository<Good> repository;
        public GoodService(IRepository<Good> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<GoodDTO> GetAll()
        {
            return repository.GetAll()
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
                repository.Delete(repository.Get(item.Id));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            repository.Save();
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

            repository.Add(temp);
            repository.Save();
        }

        public void Update(GoodDTO Item)
        {
            Good temp = new Good
            {
                GoodId = Item.Id,
                ManufacturerId = Item.ManufacturerId,
                CategoryId = Item.CategoryId,
                Price = Item.Price,
                GoodCount = Item.Count
            };
            repository.Update(temp);
            repository.Save();
        }
    }
}
