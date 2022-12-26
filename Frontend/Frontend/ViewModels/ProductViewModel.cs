using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Frontend.Models;
using Frontend.Views;
using Xamarin.Forms;
using Frontend.Services;
using System.Linq;

namespace Frontend.ViewModels
{
    [QueryProperty("CategoryID", "categoryID")]
    class ProductViewModel : INotifyPropertyChanged
    {
        private bool loaded = false;
        private List<Product> source;
        private List<Category> source1;
        public String title { get; private set; }
        public ObservableCollection<Product> productList { get; private set; }
        public ObservableCollection<Category> categoryList { get; private set; }
        public ICommand ProductTapCommand { get; set; }
        public ICommand CatTapCommand { get; set; }
        public int sortMode = 0;
        private int categoryID = 0;
        public int CategoryID
        {
            get => categoryID;
            set
            {
                categoryID = value;
                foreach (Category category in categoryList)
                {
                    if (category.ID == value)
                    {
                        title = category.Name;
                    }
                }
                CategoryFilterHandler();
                OnPropertyChanged("title");

            }
        }


        public int SortMode
        {
            get => sortMode;
            set
            {
                sortMode = value;
                if (loaded)
                {
                    OnPropertyChanged("sortMode");
                }
            }
        }
        public ProductViewModel()
        {
            
            title = "Tất cả";
            source = new List<Product>();
            source1 = new List<Category>();
            Task.Run(async () =>
            {
                await InitializeCategoryCollection();
                await InitializeProductList();
            }).Wait();


            ProductTapCommand = new Command<Product>(async (item) =>
            {
                await Shell.Current.GoToAsync($"{nameof(ProductDetailPage)}?productID={item.ProductId}");
            });
           
            CatTapCommand = new Command<Category>((item) =>
            {
                
                //title = item.Name;
                CategoryID = item.ID;
                //CategoryFilterHandler();
                //OnPropertyChanged("title");
            });
        }

        void CategoryFilterHandler()
        {
            if (CategoryID == 0)
            {
                SortModeChangeHandler(new List<Product>(source));
                return;
            }

            List<Product> products = new List<Product>(source);
            SortModeChangeHandler(products.FindAll((e) => e.CategoryID == CategoryID));
        }
        void SortModeChangeHandler(List<Product> products)
        {
            switch (sortMode)
            {
                case 1: // asc name
                    products.Sort((a, b) => String.Compare(a.Name, b.Name));
                    break;
                case 2: //desc name 
                    products.Sort((a, b) => String.Compare(b.Name, a.Name));
                    break;
                case 3: //asc price
                    products.Sort((a, b) => Convert.ToInt32(a.Price - b.Price));
                    break;
                case 4: //desc price
                    products.Sort((a, b) => Convert.ToInt32(b.Price - a.Price));

                    break;
                case 0: //default
                    break;
                default:
                    break;
            }
            productList = new ObservableCollection<Product>(products);
            OnPropertyChanged("productList");
        }

        async Task InitializeProductList()
        {
            List<Product> products = await App.productService.GetAllProduct();

            foreach (Product product in products)
            {
                source.Add(product);
            }
            productList = new ObservableCollection<Product>(source);
            OnPropertyChanged("productList");
            loaded = true;
        }

        async Task InitializeCategoryCollection()
        {
            List<Category> categories = await App.categoriesService.GetAllCategory();
            source1.Add(new Category { ID = 0, Name = "Tất cả", Image = "star.png" });
            foreach (Category category in categories)
            {
                source1.Add(category);
            }
            categoryList = new ObservableCollection<Category>(source1);
            OnPropertyChanged("categoryList");
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;


        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (propertyName == "sortMode")
            {
                SortModeChangeHandler(productList.ToList());
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
