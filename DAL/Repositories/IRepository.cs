using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        void Add(T item);
        void Delete(T item);
        void Update(T item);
        T Get(int id);
        void Save();
    }
}
