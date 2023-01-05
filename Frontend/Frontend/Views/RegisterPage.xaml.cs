using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Frontend.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PopAsync();
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {

        }
    }
}