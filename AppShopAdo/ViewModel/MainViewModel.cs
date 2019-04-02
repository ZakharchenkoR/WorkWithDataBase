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

        #region Properties
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
        private NotifyCollection<ManufacturerDTO> manufacturers;
        public NotifyCollection<ManufacturerDTO> Manufacturers
        {
            get => manufacturers;
            set
            {
                manufacturers = value;
                Notify();
            }
        }
        private NotifyCollection<CategoryDTO> categories;
        public NotifyCollection<CategoryDTO> Categories
        {
            get => categories;
            set
            {
                categories = value;
                Notify();
            }
        }
        private GoodDTO selectedGoodDTO;
        public GoodDTO SelectedGoodDTO
        {
            get => selectedGoodDTO;
            set
            {
                selectedGoodDTO = value;
                Notify();
                foreach (var item in Manufacturers)
                {
                    if(item.Id == value.ManufacturerId)
                    {
                        SelectedManufacturerDTO = item;
                        break;
                    }
                }

                foreach (var item in Categories)
                {
                    if(item.Id == value.CategoryId)
                    {
                        SelectrdCategoryDTO = item;
                        break;
                    }
                }
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
        private decimal goodDTOCount;
        public decimal GoodDTOCount
        {
            get => goodDTOCount;
            set
            {
                goodDTOCount = value;
                Notify();
            }
        }
        private string categoryDTOName;
        public string CategoryDTOName
        {
            get => categoryDTOName;
            set
            {
                categoryDTOName = value;
                Notify();
            }
        }
        private string manufacturerDTOName;

        public string ManufacturerDTOName
        {
            get => manufacturerDTOName;
            set
            {
                manufacturerDTOName = value;
                Notify();
            }
        }
        #endregion

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
            RemoveManufacturerDTO = new RelayCommand(x => Manufacturers.Remove(SelectedManufacturerDTO));
            RemoveCategoryDTO = new RelayCommand(x => Categories.Remove(SelectrdCategoryDTO));
            AddGoodDTO = new RelayCommand(AddToGoods);
            AddCategoryDTO = new RelayCommand(AddToCategory);
            AddManufacturerDTO = new RelayCommand(AddToManufacturer);
            UpdateManufacturerDTO = new RelayCommand(UpdateToManufacturerDTO);
            UpdateCategoryDTO = new RelayCommand(UpdateToCategoryDTO);
            ApplicationClose = new RelayCommand(x => Application.Current.Shutdown());
        }

        #region Commands
        public ICommand RemoveGoodDTO { get; private set; }
        public ICommand RemoveManufacturerDTO { get; private set; }
        public ICommand RemoveCategoryDTO { get; private set; }
        public ICommand AddGoodDTO { get; private set; }
        public ICommand AddCategoryDTO { get; private set; }
        public ICommand AddManufacturerDTO { get; private set; }
        public ICommand UpdateManufacturerDTO { get; private set; }
        public ICommand UpdateCategoryDTO { get; private set; }
        public ICommand UpdateGoodDTO { get; private set; }
        public ICommand ApplicationClose { get; private set; }
        #endregion

        #region Methods
        private void AddToGoods(object a)
        {
            GoodDTO temp = new GoodDTO
            {
                Name = GoodDTOName,
                ManufacturerId = SelectedManufacturerDTO.Id,
                CategoryId = SelectrdCategoryDTO.Id,
                Price = GoodDTOPrice,
                Count = GoodDTOCount
            };
            Goods.Adding(temp);
            Goods = new NotifyCollection<GoodDTO>(serviceGood);
            GoodDTOCount = 0;
            GoodDTOPrice = 0;
            GoodDTOName = string.Empty;
        }

        private void AddToCategory(object a)
        {
            CategoryDTO temp = new CategoryDTO
            {
                Name = CategoryDTOName
            };
            Categories.Adding(temp);
            Categories = new NotifyCollection<CategoryDTO>(serviceCategory);
            CategoryDTOName = string.Empty;
        }

        private void AddToManufacturer(object a)
        {
            ManufacturerDTO temp = new ManufacturerDTO
            {
                Name = ManufacturerDTOName
            };
            Manufacturers.Adding(temp);
            Manufacturers = new NotifyCollection<ManufacturerDTO>(seviceManufacturer);
            ManufacturerDTOName = string.Empty;
        }

        private void UpdateToManufacturerDTO(object a)
        {
            ManufacturerDTO temp = new ManufacturerDTO
            {
                Id = SelectedManufacturerDTO.Id,
                Name = SelectedManufacturerDTO.Name
            };
            Manufacturers.Update(temp);
            Manufacturers = new NotifyCollection<ManufacturerDTO>(seviceManufacturer);
        }

        private void UpdateToCategoryDTO(object a)
        {
            CategoryDTO temp = new CategoryDTO
            {
                Id = SelectrdCategoryDTO.Id,
                Name = SelectrdCategoryDTO.Name
            };
            Categories.Update(temp);
            Categories = new NotifyCollection<CategoryDTO>(serviceCategory);
        }

        private void UpdateToGoodDTO(object a)
        {
            GoodDTO temp = new GoodDTO
            {
                Id = SelectedGoodDTO.Id,
                Name = SelectedGoodDTO.Name,
                ManufacturerId = SelectedGoodDTO.ManufacturerId,
                CategoryId = SelectedGoodDTO.CategoryId,
                Price = SelectedGoodDTO.Price,
                Count = SelectedGoodDTO.Count
            };
            Goods.Update(temp);
            Goods = new NotifyCollection<GoodDTO>(serviceGood);
        }
        #endregion

        private void Notify([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
