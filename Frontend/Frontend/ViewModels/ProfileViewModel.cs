using Frontend.Models;
using Frontend.Services;
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

            SaveProfileCommand = new Command(async () =>
            {
                bool confirm = await Shell.Current.DisplayAlert("Thông báo", "Bạn có chắc thay đổi những thông tin này", "Xác nhận", "Thoát");
                if (confirm)
                {
                    await UserService.UpdateUser(_user);
                    await Shell.Current.GoToAsync("..");
                }
                else
                    await Shell.Current.GoToAsync("..");
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
