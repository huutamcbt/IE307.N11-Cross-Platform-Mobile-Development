using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Frontend.Models;

namespace Frontend.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        private List<CarouselItem> carouselList = new List<CarouselItem>();
        public HomePage()
        {
            InitializeComponent();
            CultureInfo myCurrency = new CultureInfo("vi-VN");
            CultureInfo.DefaultThreadCurrentCulture = myCurrency;
            HomeCarouselInitial();



        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (!App.isLogin)
            {
                await Shell.Current.GoToAsync($"/{nameof(LoginPage)}");
            }
        }
        private void HomeCarouselInitial()
        {
            Device.StartTimer(TimeSpan.FromSeconds(7), (Func<bool>)(() =>
            {
                HomeCarousel.Position = (HomeCarousel.Position + 1) %4;
                return true;
            }));
        }
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
           await Shell.Current.GoToAsync($"/{nameof(ProductPage)}");
        }

        private  void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
        }

        private  void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
        }

        private  void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
        }

        private async void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"/{nameof(CartPage)}");
        }


    }
}