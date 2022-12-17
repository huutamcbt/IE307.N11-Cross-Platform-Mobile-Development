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
    class ProductViewModel : INotifyPropertyChanged
    {
        readonly IList<Product> source;
        public ObservableCollection<Product> productList { get; private set; }
        public ICommand ProductTapCommand { get; set; }

        public ProductViewModel()
        {
            source = new List<Product>();
            CreateItemCollection();

            ProductTapCommand = new Command<Product>(async (item) =>
            {
                await Shell.Current.GoToAsync($"{nameof(ProductDetailPage)}?productID={item.ProductId}");
            });
        }



        async void CreateItemCollection()
        {
            ProductService productService = new ProductService();
            List<Product> products = await productService.GetAllProduct();
            foreach (Product product in products)
            {
                source.Add(product);
            }
            productList = new ObservableCollection<Product>(source);
            OnPropertyChanged("productList");
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
