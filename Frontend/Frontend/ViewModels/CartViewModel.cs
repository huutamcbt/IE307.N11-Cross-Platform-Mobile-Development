using Frontend.Models;
using Frontend.Services;
using Frontend.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Frontend.ViewModels
{
    class CartViewModel : INotifyPropertyChanged
    {

        public IList<Product> source;
        public ObservableCollection<Product> productList { get; private set; }
        public double Total { get; set; }

        public ICommand PlaceOrderCommand { get; private set; }
        public ICommand RemoveCommand { get; private set; }
        public ICommand PlusCommand { get; private set; }
        public ICommand SubCommand { get; private set; }

        public CartViewModel()
        {
            source = new List<Product>();
            PlaceOrderCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync($"/{nameof(OrderPage)}");
            });
            RemoveCommand = new Command<Product>(async (product) =>
            {
                var response = await CartService.RemoveItem(product);
                source.Remove(product);
                Total -= product.Price * product.Quantity;
                productList = new ObservableCollection<Product>(source);
                OnPropertyChanged("productList");
                OnPropertyChanged("Total");
            });
            PlusCommand = new Command<Product>(async (product) =>
            {
                if (product.Quantity > product.Stock)
                {
                    await Shell.Current.DisplayAlert("Thông báo", "Không thể tăng thêm nữa", "ok");
                    return;
                }
                int index = source.IndexOf(product);
                product.Quantity++;
                Total += product.Price;
                var response = await CartService.UpdateItem(product);
                source[index] = product;
                productList = new ObservableCollection<Product>(source);
                OnPropertyChanged("productList");
                OnPropertyChanged("Total");
            });
            SubCommand = new Command<Product>(async (product) =>
            {
                if (product.Quantity == 1)
                {
                    await Shell.Current.DisplayAlert("Thông báo", "Không thể giảm thêm nữa", "ok");
                    return;
                }
                int index = source.IndexOf(product);
                product.Quantity--;
                Total -= product.Price;
                var response = await CartService.UpdateItem(product);
                source[index] = product;
                productList = new ObservableCollection<Product>(source);
                OnPropertyChanged("productList");
                OnPropertyChanged("Total");
            });
            Task.Run(async () =>
            {
                await initializeCartItem();
            }).Wait();

        }

        async Task initializeCartItem()
        {
            List<Product> products = await CartService.getCartItem();
            Total = 0;
            foreach (Product product in products)
            {
                source.Add(product);
                Total += product.Price * product.Quantity;

            }
            productList = new ObservableCollection<Product>(source);
            OnPropertyChanged("productList");
            OnPropertyChanged("Total");

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
