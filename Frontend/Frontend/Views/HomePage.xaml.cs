﻿using System;
using System.Collections.Generic;
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
        }
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
        }

        private async void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
        }

        private async void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
        }

        protected override bool OnBackButtonPressed()
        {
            return false;
        }
    }
}