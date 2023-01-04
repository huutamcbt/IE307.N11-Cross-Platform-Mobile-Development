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
        public int SHIPCOST { get; private set; }
        public IList<Product> source;
        public ObservableCollection<Product> productList { get; private set; }

        private IList<UserAddress> sourse1;
        public ObservableCollection<UserAddress> addressList { get; private set; }
        public double Total { get; set; }
        int addressPickerIndex ;
        public int AddressPickerIndex { 
            get => addressPickerIndex;
            set {
                addressPickerIndex = value;
                OnPropertyChanged("AddressPickerIndex");
            } 
        }
        int paymentMethodPickerIndex = 0;
        public int PaymentMethodPickerIndex
        {
            get => paymentMethodPickerIndex;
            set
            {
                paymentMethodPickerIndex = value;
                OnPropertyChanged("PaymentMethodPickerIndex");
            }
        }

        public ICommand PlaceOrderCommand { get; private set; }
        public OrderViewModel()
        {
            SHIPCOST = 30000;
            OnPropertyChanged("SHIPCOST");
            source = new List<Product>();
            sourse1 = new List<UserAddress>();
            PlaceOrderCommand = new Command(async() => {
                List<OrderItem> orderItems = new List<OrderItem>();
                foreach (Product product in productList)
                {
                    orderItems.Add(new OrderItem {ProductId = product.ProductId, Quantity=product.Quantity });
                }
                var response = await OrderService.PlaceOrder(orderItems, Total);
                if (response.IsSuccessStatusCode)
                {
                    await Shell.Current.DisplayAlert("Thông báo", "Đặt hàng thành công! \n bạn sẽ được đưa về trang chủ", "ok");
                    await Shell.Current.GoToAsync($"//Main/{nameof(HomePage)}");
                }
            
            });
            Task.Run(async () =>
            {
                await InitializeAddresses();
            }).Wait();
            Task.Run(async () =>
            {
                await initializeCartItem();
                addressPickerIndex = 0;
                OnPropertyChanged("AddressPickerIndex");

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
