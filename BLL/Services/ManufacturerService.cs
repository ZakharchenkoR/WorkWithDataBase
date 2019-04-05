using BLL.Models.ManufacturerDTO;
using DAL.Context;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ManufacturerService : IService<ManufacturerDTO>
    {
        private IUnitOfWork unitOfWork;

        public ManufacturerService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<ManufacturerDTO> GetAll()
        {
            return unitOfWork.Manufacturer.GetAll().Select(x => new ManufacturerDTO
            {
                Id = x.ManufacturerId,
                Name = x.ManufacturerName
            });
        }

        public void Remove(ManufacturerDTO item)
        {
            unitOfWork.Manufacturer.Delete(unitOfWork.Manufacturer.Get(item.Id));
            unitOfWork.Save();
        }


        public void Add(ManufacturerDTO item)
        {
            Manufacturer temp = new Manufacturer
            {
                ManufacturerName = item.Name
            };
            unitOfWork.Manufacturer.Add(temp);
            unitOfWork.Save();
        }

        public void Update(ManufacturerDTO Item)
        {
            Manufacturer temp = new Manufacturer
            {
                ManufacturerId = Item.Id,
                ManufacturerName = Item.Name
            };
            unitOfWork.Manufacturer.Update(temp);
            unitOfWork.Save();
        }
    }
}
