using Frontend.Models;
using Frontend.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace Frontend.ViewModels
{
    [QueryProperty("OrderId", "OrderId")]
    [QueryProperty("AddressId", "AddressId")]
    class OrderDetailViewModel: INotifyPropertyChanged
    {
        private int orderId;
        public int OrderId
        {
            get => orderId;
            set
            {
                orderId = value;
                InitializeOrder();
            }
        }
        private int addressId;
        public int AddressId
        {
            get => addressId;
            set
            {
                addressId = value;
                InitializeAddress();
            }
        }
        public IList<Product> source;
        public ObservableCollection<Product> productList { get; private set; }
        public UserAddress userAddress { get; set; }
        public PaymentDetail paymentDetail { get; set; }
        public OrderDetailViewModel()
        {
            source = new List<Product>();
        }
        private async void InitializeOrder()
        {
            List<OrderItem> orderItems = await OrderService.GetOrderItemsByOrderId(orderId);
            foreach(OrderItem orderItem in orderItems)
            {
                Product product = await ProductService.GetProductByProductId(orderItem.ProductId);
                product.Quantity = orderItem.Quantity;
                source.Add(product);
            }
            productList = new ObservableCollection<Product>(source);
            paymentDetail = new PaymentDetail { OrderId = 1, CreatedDate = DateTime.Now };
            OnPropertyChanged("paymentDetail");
            OnPropertyChanged("productList");
        }
        private async void InitializeAddress()
        {
            userAddress = await AddressService.GetAddressesByAddressId(addressId);
            userAddress.Display = $"{userAddress.Mobile}\n{userAddress.Address}, {userAddress.District}, {userAddress.City}, {userAddress.Country}";
            OnPropertyChanged("userAddress");

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
