using Frontend.Models;
using Frontend.Services;
using Frontend.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Frontend.ViewModels
{
    class OrderHistoryViewModel: INotifyPropertyChanged
    {
        private IList<OrderDetail> sourse;
        public ObservableCollection<OrderDetail> orderList { get; private set; }
        public ICommand OrderTapCommand { get; private set; }
        public OrderHistoryViewModel()
        {
            sourse = new List<OrderDetail>();
            OrderTapCommand = new Command<OrderDetail>(async (orderDetail) => {
                await Shell.Current.GoToAsync($"{nameof(OrderDetailPage)}?OrderId={orderDetail.OrderId}&AddressId={orderDetail.AddressId}");
            });
            Task.Run(async () =>
            {
                await InitializeOrders();
            }).Wait();
        }
        async Task InitializeOrders()
        {
            List < OrderDetail >  orders= await OrderService.GetOrderDetail();
            foreach(OrderDetail order in orders)
            {
                sourse.Add(order);
            }
            orderList = new ObservableCollection<OrderDetail>(sourse);
            OnPropertyChanged("orderList");
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
