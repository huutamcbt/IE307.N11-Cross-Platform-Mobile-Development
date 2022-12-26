using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Frontend.ViewModels
{


    class RegisterViewModel : INotifyPropertyChanged
    {
        public String username;
        public String password { private get; set; }
        public String passwordConfirm { private get; set; }
        public String firstName;
        public String lastName;
        public String telephone;




        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
