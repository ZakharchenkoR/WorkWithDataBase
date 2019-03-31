using BLL.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShopAdo.Utils
{
    class NotifyCollection<T>:ObservableCollection<T> where T:class
    {
        IService<T> service;
        public NotifyCollection(IService<T> service)
        {
            this.service = service;
       
            foreach (var item in service.GetAll())
            {
                this.Add(item);
            }
        }

        public new void Remove(T item)
        {
            base.Remove(item);
            service.Remove(item);
        }

        public void Adding(T item)
        {
            base.Add(item);
            service.Add(item);
        }

    }
}
