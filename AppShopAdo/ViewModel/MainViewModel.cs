using AppShopAdo.Utils;
using BLL.Models.CategoryDTO;
using BLL.Models.GoodDTO;
using BLL.Models.ManufacturerDTO;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AppShopAdo.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        private IService<GoodDTO> serviceGood;
        private IService<ManufacturerDTO> seviceManufacturer;
        private IService<CategoryDTO> serviceCategory;
        private NotifyCollection<GoodDTO> goods;
        public NotifyCollection<GoodDTO> Goods
        {
            get => goods;
            set
            {
                goods = value;
                Notify();
            }
        }
        public NotifyCollection<ManufacturerDTO> Manufacturers { get; set; }
        public NotifyCollection<CategoryDTO> Categories { get; set; }
        private GoodDTO selectedGoodDTO;
        public GoodDTO SelectedGoodDTO
        {
            get => selectedGoodDTO;
            set
            {
                selectedGoodDTO = value;
                Notify();
            }
        }
        private ManufacturerDTO selectedManufacturerDTO;
        public ManufacturerDTO SelectedManufacturerDTO
        { get => selectedManufacturerDTO;
            set
            {
                selectedManufacturerDTO = value;
                Notify();
            }
        }
        private CategoryDTO selectedCategoryDTO;
        public CategoryDTO SelectrdCategoryDTO
        {
            get => selectedCategoryDTO;
            set
            {
                selectedCategoryDTO = value;
                Notify();
            }
        }
        private string goodDTOName;
        public string GoodDTOName
        {
            get => goodDTOName;
            set
            {
                goodDTOName = value;
                Notify();
            }
        }
        private decimal goodDTOPrice;
        public decimal GoodDTOPrice
        {
            get => goodDTOPrice;
            set
            {
                goodDTOPrice = value;
                Notify();
            }
        }
        public decimal goodDTOCount;
        public decimal GoodDTOCount
        {
            get => goodDTOCount;
            set
            {
                goodDTOCount = value;
                Notify();
            }
        }
       
        public MainViewModel(IService<GoodDTO> serviceGood, IService<ManufacturerDTO> seviceManufacturer, IService<CategoryDTO> serviceCategory)
        {
            this.serviceGood = serviceGood;
            this.seviceManufacturer = seviceManufacturer;
            this.serviceCategory = serviceCategory;
            Goods = new NotifyCollection<GoodDTO>(serviceGood);
            Manufacturers = new NotifyCollection<ManufacturerDTO>(seviceManufacturer);
            Categories = new NotifyCollection<CategoryDTO>(serviceCategory);
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            RemoveGoodDTO = new RelayCommand(x => Goods.Remove(SelectedGoodDTO));
            AddGoodDTO = new RelayCommand(AddToGoods);
        }

        #region Commands
        public ICommand RemoveGoodDTO { get; private set; }
        public ICommand AddGoodDTO { get; private set; }
        #endregion

        public void AddToGoods(object a)
        {
            GoodDTO temp = new GoodDTO
            {
                Name = GoodDTOName,
                ManufacturerId = SelectedManufacturerDTO.Id as int?,
                CategoryId = SelectrdCategoryDTO.Id as int?,
                Price = GoodDTOPrice,
                Count = GoodDTOCount
            };
            Goods.Adding(temp);
            Goods = new NotifyCollection<GoodDTO>(serviceGood);
            GoodDTOCount = 0;
            GoodDTOPrice = 0;
            GoodDTOName = string.Empty;
        }
        private void Notify([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
