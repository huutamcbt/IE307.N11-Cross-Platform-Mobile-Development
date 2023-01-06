using Frontend.Models;
using Frontend.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Frontend.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {

        public LoginPage()
        {

            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (App.isLogin)
            {
                await Shell.Current.GoToAsync($"//Main/{nameof(HomePage)}");
            }
        }
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(RegisterPage));
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(RegisterPage));
        }   


        private async void Button_Clicked(object sender, EventArgs e)
        {
            var reponse = await UserService.Login(new User { Username = entryUsername.Text, Password = entryPassword.Text });
            if (reponse.IsSuccessStatusCode)
            {
                App.isLogin = true;
                await Shell.Current.GoToAsync($"//Main/{nameof(HomePage)}");
            }
            else
            {
                await Shell.Current.DisplayAlert("Đăng nhập sai", "Thông tin tài khoản hoặc mật khẩu không chính xác", "ok");
            }
        }
    }
}