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
    class OrderViewModel : INotifyPropertyChanged
    {
        const int SHIPCOST = 30000;
        public IList<Product> source;
        public ObservableCollection<Product> productList { get; private set; }

        private IList<UserAddress> sourse1;
        public ObservableCollection<UserAddress> addressList { get; private set; }
        public double Total { get; set; }
        public OrderViewModel()
        {
            source = new List<Product>();
            sourse1 = new List<UserAddress>();
            Task.Run(async () =>
            {
                await initializeCartItem();
            }).Wait();
            Task.Run(async () =>
            {
                await InitializeAddresses();
            }).Wait();
        }
        async Task InitializeAddresses()
        {
            List<UserAddress> userAddresses = await AddressService.GetAddressesByUserId(1);
            foreach (UserAddress address in userAddresses)
            {
                address.Display = $"{address.Mobile}\n{address.Address}, {address.District}, {address.City}, {address.City}";
                sourse1.Add(address);
            }
            addressList = new ObservableCollection<UserAddress>(sourse1);
            OnPropertyChanged("addressList");
        }
        async Task initializeCartItem()
        {
            List<Product> products = await CartService.getCartItem();
            
            Total = SHIPCOST;
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
