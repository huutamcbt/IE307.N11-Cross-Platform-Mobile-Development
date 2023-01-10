using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace Frontend.ViewModels
{
    [QueryProperty("OrderId", "OrderId")]
    class OrderDetailViewModel: INotifyPropertyChanged
    {
        private int orderId;
        public int OrderId
        {
            get => orderId;
            set
            {
                orderId = value;
                //initializeProduct(value);
            }
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
