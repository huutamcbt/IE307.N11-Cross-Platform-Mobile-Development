using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frontend.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Frontend.Models;


namespace Frontend.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
   
    public partial class ProductDetailPage : ContentPage
    {
        public int productID;
        public ProductDetailPage()
        {
            InitializeComponent();
            //InitializeProduct();
        }

        //private async void InitializeProduct()
        //{
        //    ProductService service = new ProductService();
        //    Product product = await service.GetProductByProductID(productID);
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