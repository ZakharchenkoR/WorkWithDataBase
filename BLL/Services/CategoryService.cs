using BLL.Models.CategoryDTO;
using DAL.Context;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CategoryService : IService<CategoryDTO>
    {
        IRepository<Category> repository;

        public CategoryService(IRepository<Category> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<CategoryDTO> GetAll()
        {
            return repository.GetAll().Select(x => new CategoryDTO
            {
                Id = x.CategoryId,
                Name = x.CategoryName
            });
        }

        public void Remove(CategoryDTO item)
        {
            repository.Delete(repository.Get(item.Id));
            repository.Save();
        }

        public void Add(CategoryDTO item)
        {
            Category temp = new Category
            {
                CategoryName = item.Name
            };

            repository.Add(temp);
            repository.Save();
        }
    }
}
