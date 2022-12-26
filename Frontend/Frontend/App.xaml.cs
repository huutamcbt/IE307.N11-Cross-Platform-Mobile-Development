﻿//using Frontend.Services;
using Frontend.Models;
using Frontend.Views;
using Frontend.Services;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Frontend
{

    public partial class App : Application
    {
        public static bool isLogin = false;

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }


        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
