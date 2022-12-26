//using Frontend.Services;
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
        //static ObservableCollection<Product> productsInCart;
        //static List<Product> allProducts { get;  set; }
        public static ProductService productService = new ProductService();
        public static CategoriesService categoriesService = new CategoriesService();
        public static bool isLogin = false;

        public App()
        {
            InitializeComponent();
            //Task.Run(async () =>
            //{
            //}).Wait();
            //DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }
        //public static List<Product> GetAllProducts()
        //{
        //    return allProducts;
        //}




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
