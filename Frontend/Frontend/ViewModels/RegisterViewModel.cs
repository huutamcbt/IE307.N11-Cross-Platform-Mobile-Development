using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Frontend.ViewModels
{


    class RegisterViewModel : INotifyPropertyChanged
    {
        string username = "";
        public String Username { get => username; set { username = value; } }
        string password = "";
        public String Password { get => password; set { password = value; } }
        string passwordConfirm;
        public String PasswordConfirm { get => passwordConfirm; set { passwordConfirm = value; } }
        public string firstName = "";
        public String FirstName { get => firstName; set { firstName = value; } }
        string lastName = "";
        public String LastName { get => lastName; set { lastName = value; } }
        string telephone = "";
        public String Telephone { get => telephone; set { telephone = value; } }




        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
