using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppShopAdo.ViewModel;
using BLL.Modules;
using Ninject;

namespace AppShopAdo.Utils
{
    class MainViewModelLocator
    {
        IKernel kernel;
        public MainViewModelLocator()
        {
            kernel = new StandardKernel(new ShopAdoDIModule());
        }
        public MainViewModel ViewModel => kernel.Get<MainViewModel>();
    }
}
