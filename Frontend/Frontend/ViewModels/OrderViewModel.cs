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
    class OrderViewModel : INotifyPropertyChanged
    {
        public int SHIPCOST { get; private set; }
        public IList<Product> source;
        public ObservableCollection<Product> productList { get; private set; }

        private IList<UserAddress> sourse1;
        public ObservableCollection<UserAddress> addressList { get; private set; }
   
        public double Total { get; set; }
        int addressPickerIndex;
        public int AddressPickerIndex
        {
            get => addressPickerIndex;
            set
            {
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
            PlaceOrderCommand = new Command(async () =>
            {
                List<OrderItem> orderItems = new List<OrderItem>();
                foreach (Product product in productList)
                {
                    orderItems.Add(new OrderItem { ProductId = product.ProductId, Quantity = product.Quantity });
                }
                var response = await OrderService.PlaceOrder(orderItems, Total,addressList[addressPickerIndex].AddressId);
                if (response.IsSuccessStatusCode)
                {
                    await Shell.Current.DisplayAlert("Thông báo", "Đặt hàng thành công! \n bạn sẽ được đưa về trang chủ", "ok");
                    await Shell.Current.GoToAsync($"//Main/{nameof(HomePage)}");
                }

            });
            Task.Run(async () =>
            {
                await InitializeAddresses();
                await InitializeCartItem();

            }).Wait();
        }
        async Task InitializeAddresses()
        {
            List<UserAddress> userAddresses = await AddressService.GetAddressesByUserId(1);
            foreach (UserAddress address in userAddresses)
            {
                address.Display = $"{address.Mobile}\n{address.Address}, {address.District}, {address.City}, {address.Country}";
                sourse1.Add(address);
            }
            addressList = new ObservableCollection<UserAddress>(sourse1);
            addressPickerIndex = 1;
            OnPropertyChanged("AddressPickerIndex");
        }
        async Task InitializeCartItem()
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
