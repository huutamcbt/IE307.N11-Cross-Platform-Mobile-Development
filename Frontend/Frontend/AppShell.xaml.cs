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
            Routing.RegisterRoute(nameof(ProductPage), typeof(ProductPage));
            Routing.RegisterRoute(nameof(CategoriesPage), typeof(CategoriesPage));
            Routing.RegisterRoute(nameof(ProductPage), typeof(ProductPage));
            Routing.RegisterRoute(nameof(BlogPage), typeof(BlogPage));
        }

    }
}
