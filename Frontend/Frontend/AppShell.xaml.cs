using Frontend.ViewModels;
using Frontend.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Frontend
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(ProductPage), typeof(ProductPage));
            Routing.RegisterRoute(nameof(ProductDetailPage), typeof(ProductDetailPage));
            Routing.RegisterRoute(nameof(BlogPage), typeof(BlogPage));
            Routing.RegisterRoute(nameof(CartPage), typeof(CartPage));
            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(TestPage), typeof(TestPage));
        }

    }
}
