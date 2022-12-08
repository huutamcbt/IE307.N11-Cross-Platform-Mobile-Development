﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Frontend.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            CultureInfo myCurrency = new CultureInfo("vi-VN");
            CultureInfo.DefaultThreadCurrentCulture = myCurrency;
        }
        private  void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            
           //await Shell.Current.GoToAsync($"{nameof(ProductPage)}?ID={ProductID}");
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

        protected override bool OnBackButtonPressed()
        {
            return false;
        }

        private async void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(CartPage));
        }
    }
}