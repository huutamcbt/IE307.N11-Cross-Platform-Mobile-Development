using Frontend.Models;
using Frontend.Services;
using Frontend.Views;
using Rg.Plugins.Popup.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Frontend.ViewModels
{
    class AddressViewModel : INotifyPropertyChanged
    {

        private IList<UserAddress> sourse;
        public ObservableCollection<UserAddress> addressList { get; private set; }



        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public AddressViewModel()
        {
            sourse = new List<UserAddress>();
            MessagingCenter.Subscribe<AddressPopupPage>(this, "refresh", async (sender) =>
             {
                 sourse = new List<UserAddress>();
                 await InitializeAddresses();
                 // Do something whenever the "Hi" message is received
             });
            DeleteCommand = new Command<UserAddress>(async (address) =>
            {
                bool confirm = await Shell.Current.DisplayAlert("Thông báo", "Bạn có chắc xóa địa chỉ này không", "Có", "Không");
                if (confirm)
                {
                    await AddressService.RemoveAddress(address);
                    sourse.Remove(address);
                    addressList = new ObservableCollection<UserAddress>(sourse);
                    OnPropertyChanged("addressList");
                    await Shell.Current.DisplayAlert("Thông báo", "Đã xóa thành công", "ok");
                }

            });
            EditCommand = new Command<UserAddress>(async (address) =>
            {

                await PopupNavigation.Instance.PushAsync(new AddressPopupPage(address));
            });
            AddCommand = new Command(async () =>
            {
                await PopupNavigation.Instance.PushAsync(new AddressPopupPage());
            });
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
                sourse.Add(address);
            }
            addressList = new ObservableCollection<UserAddress>(sourse);
            OnPropertyChanged("addressList");
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