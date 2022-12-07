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

namespace Frontend.ViewModels
{
    class ItemPreviewViewModel: INotifyPropertyChanged
    {
        readonly IList<Product> source;
        public ObservableCollection<Product> productList { get; private set; }


        readonly IList<Category> source1;
        public ObservableCollection<Category> categoryList { get; private set; }

        public ICommand ItemTapCommand { get; set; }

        public ICommand CatTapCommand { get; set; }
        
        public ItemPreviewViewModel()
        {
            source = new List<Product>();
            source1 = new List<Category>();

            ItemTapCommand = new Command<Category>(async (items) =>
            {
                await Shell.Current.GoToAsync(nameof(ProductPage));
            });

            CatTapCommand = new Command<Category>(async(items )=>
            {
                int CategoryID = items.ID;
                await Shell.Current.GoToAsync($"{nameof(CategoriesPage)}?ID={CategoryID}");
            });

            CreateItemCollection();
            CreateCategoriesCollection();
        }


        async void CreateCategoriesCollection()
        {
            CategoriesService categoriesService = new CategoriesService();
            List<Category> categories = await categoriesService.GetAllCategory();
            foreach (Category category in categories)
            {
                source1.Add(category);
            }
            categoryList = new ObservableCollection<Category>(source1);
        }
        async void CreateItemCollection()
        {
            ProductService productService = new ProductService();
            List < Product > products = await productService.GetAllProduct();
            foreach(Product product in products)
            {
                source.Add(product);
            }
            productList = new ObservableCollection<Product>(source);
        }
 

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
