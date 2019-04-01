using BLL.Models.ManufacturerDTO;
using DAL.Context;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ManufacturerService : IService<ManufacturerDTO>
    {
        IRepository<Manufacturer> repository;

        public ManufacturerService(IRepository<Manufacturer> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<ManufacturerDTO> GetAll()
        {
            return repository.GetAll().Select(x => new ManufacturerDTO
            {
                Id = x.ManufacturerId,
                Name = x.ManufacturerName
            });
        }

        public void Remove(ManufacturerDTO item)
        {
            repository.Delete(repository.Get(item.Id));
            repository.Save();
        }


        public void Add(ManufacturerDTO item)
        {
            Manufacturer temp = new Manufacturer
            {
                ManufacturerName = item.Name
            };
            repository.Add(temp);
            repository.Save();
        }

        public void Update(ManufacturerDTO Item)
        {
            Manufacturer temp = new Manufacturer
            {
                ManufacturerId = Item.Id,
                ManufacturerName = Item.Name
            };
            repository.Update(temp);
            repository.Save();
        }
    }
}
