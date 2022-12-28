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
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            App.isLogin = false;
            await Shell.Current.GoToAsync($"//Main/{nameof(HomePage)}");
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"{nameof(EditProfilePage)}");
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"{nameof(EditAddressPage)}");
        }

        private async void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"{nameof(OrderHistoryPage)}");
        }
        private async void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"{nameof(TrackOrderPage)}");
        }

        private void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {

        }
    }
}