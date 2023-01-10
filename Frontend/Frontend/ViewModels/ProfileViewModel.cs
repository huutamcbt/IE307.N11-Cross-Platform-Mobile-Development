using Frontend.Models;
using Frontend.Services;
using Frontend.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Frontend.ViewModels
{
    class ProfileViewModel : INotifyPropertyChanged
    {
        public string Name { get; private set; }

        private User _user { get; set; }

        public User user
        {
            get => _user;
            set
            {
                _user = value;
            }
        }



        public ICommand SaveProfileCommand { get; set; }
        public ProfileViewModel()
        {
            Task.Run(async () =>
            {
                await InitializeProfile();
            }).Wait();
            MessagingCenter.Subscribe<ProfileViewModel>(this, "refresh", async (sender) =>
            {
                await InitializeProfile();
                // Do something whenever the "Hi" message is received
            });
            SaveProfileCommand = new Command(async () =>
            {
                bool confirm = await Shell.Current.DisplayAlert("Thông báo", "Bạn có chắc thay đổi những thông tin này", "Xác nhận", "Thoát");
                if (confirm)
                {
                    var response = await UserService.UpdateUser(_user);
                    if (response.IsSuccessStatusCode)
                    {
                        await Shell.Current.DisplayAlert("Thông báo", "Cập nhật thành công!", "ok");
                        MessagingCenter.Send<ProfileViewModel>(this, "refresh");
                        await Shell.Current.GoToAsync("..");
   
                    }
                    else
                    {
                        await Shell.Current.DisplayAlert("Thông báo", "Cập nhật thất bại!", "ok");
                    }
                }

            });

        }

        async Task InitializeProfile()
        {
            _user = await UserService.GetUser();
            Name = _user.FirstName + " " + _user.LastName;
            OnPropertyChanged("Name");
            OnPropertyChanged("user");
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
