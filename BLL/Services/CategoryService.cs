using BLL.Models.CategoryDTO;
using DAL.Context;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CategoryService : IService<CategoryDTO>
    {
        private IUnitOfWork unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        

        public IEnumerable<CategoryDTO> GetAll()
        {
            
            return unitOfWork.Category.GetAll().Select(x => new CategoryDTO
            {
                Id = x.CategoryId,
                Name = x.CategoryName
            });
        }

        public void Remove(CategoryDTO item)
        {
            unitOfWork.Category.Delete(unitOfWork.Category.Get(item.Id));
            unitOfWork.Save();
        }

        public void Add(CategoryDTO item)
        {
            Category temp = new Category
            {
                CategoryName = item.Name
            };

            unitOfWork.Category.Add(temp);
            unitOfWork.Save();
        }

        public void Update(CategoryDTO Item)
        {
            Category temp = new Category
            {
                CategoryId = Item.Id,
                CategoryName = Item.Name
            };
            unitOfWork.Category.Update(temp);
            unitOfWork.Save();
        }
    }
}
