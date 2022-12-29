using Frontend.Models;
using Frontend.Services;
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
    class AddressViewModel : INotifyPropertyChanged
    {

        private IList<UserAddress> sourse;
        public ObservableCollection<UserAddress> addressList { get; private set; }



        public ICommand SaveProfileCommand { get; set; }
        public AddressViewModel()
        {
            Task.Run(async () =>
            {
                await InitializeAddresses();
            }).Wait();

            SaveProfileCommand = new Command(async () =>
            {
                //bool confirm = await Shell.Current.DisplayAlert("Thông báo", "Bạn có chắc thay đổi những thông tin này", "Xác nhận", "Thoát");
                //if (confirm)
                //{
                //    await UserService.UpdateUser(_user);
                //    await Shell.Current.GoToAsync("..");
                //}
                //else
                //    await Shell.Current.GoToAsync("..");
            });

        }

        async Task InitializeAddresses()
        {
            
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