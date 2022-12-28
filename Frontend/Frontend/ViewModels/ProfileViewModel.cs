using Frontend.Models;
using Frontend.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.ViewModels
{
    class ProfileViewModel : INotifyPropertyChanged
    {
        public string Name { get; private set; }
        public string Telephone { get; private set; }
        public string Logo { get; private set; }

        public ProfileViewModel(){
            Task.Run(async () =>
            {
                await InitializeProfile();
            }).Wait();
            
        }

        async Task InitializeProfile()
        {
            User user = await UserService.GetUser();
            Name = user.Firstname + " " + user.Lastname;
            Telephone = user.Telephone;
            Logo = user.Logo;
            OnPropertyChanged("Name");
            OnPropertyChanged("Telephone");
            OnPropertyChanged("Logo");
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
