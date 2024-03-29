﻿using Frontend.Models;
using Frontend.Services;
using System;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace Frontend.ViewModels
{


    class RegisterViewModel :  INotifyPropertyChanged
    {
        string username = "";
        public String Username { get => username; set { username = value; } }
        string password = "";
        public String Password { get => password; set { password = value; } }
        string passwordConfirm;
        public String PasswordConfirm { get => passwordConfirm; set { passwordConfirm = value;} }
        public string firstName = "";
        public String FirstName { get => firstName; set { firstName = value; } }
        string lastName = "";
        public String LastName { get => lastName; set { lastName = value; } }
        string telephone = "";
        public String Telephone { get => telephone; set { telephone = value; } }
        public ICommand RegisterCommand { get; private set; }

        public RegisterViewModel()
        {
            RegisterCommand = new Command(async () =>
            {
                // await call account service
                User user = new User { UserId = 0, Username = username, Password = password, FirstName = firstName, LastName = lastName, Telephone = telephone,CreatedDate= DateTime.Now,ModifiedDate= DateTime.Now,  Logo = "Profile.webp" };
                HttpResponseMessage response = await UserService.AddUser(user);

                if (response.IsSuccessStatusCode)
                {
                    await Shell.Current.DisplayAlert("Thông báo", "Tạo tài khoản thành công", "ok");
                    await Shell.Current.Navigation.PopAsync();
                }
                else
                {
                    await Shell.Current.DisplayAlert("Thông báo", "Tạo tài khoản thất bại" , "ok");
                }

                //await Shell.Current.DisplayAlert("a", $"username: {username}, \npassword: {password}, \npasswordConfirm: {passwordConfirm}, \nfirstName: {firstName}, \nlastName: {lastName},, \ntelephone: {telephone}", "ok");



            });
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
