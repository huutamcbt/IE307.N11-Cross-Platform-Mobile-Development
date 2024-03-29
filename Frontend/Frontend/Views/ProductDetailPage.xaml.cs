﻿using System;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Frontend.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class ProductDetailPage : ContentPage
    {
        public ICommand GoBackCommand;

        public ProductDetailPage()
        {
            InitializeComponent();

            GoBackCommand = new Command(async () =>
            {
                Debug.WriteLine(Shell.Current.CurrentItem.CurrentItem.Route);
                await Shell.Current.GoToAsync("..");
            });
            //InitializeProduct();
        }

        //private async void InitializeProduct()
        //{
        //    ProductService service = new ProductService();
        //    Product product = await service.GetProductByProductId(ProductId);
        //    labelProductName.Text = product.Name;
        //    labelProductDescription.Text = product.Description;
        //    imageMain.Source = product.Image;
        //}

        private void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
        {

        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }
    }
}