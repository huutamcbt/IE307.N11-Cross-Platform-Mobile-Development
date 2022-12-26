using Frontend.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Frontend.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        
        public LoginPage()
        {
            if (App.isLogin)
            {
                Shell.Current.GoToAsync(nameof(HomePage));
            }
            InitializeComponent();
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
            Console.WriteLine(entryUsername.Text + entryPassword.Text);
            App.isLogin = true;
            await Shell.Current(nameof(HomePage));
        }
    }
}