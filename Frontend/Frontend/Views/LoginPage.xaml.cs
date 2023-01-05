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
            
            App.isLogin = true;
            await Shell.Current.GoToAsync($"//Main/{nameof(HomePage)}");
        }
    }
}