using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Frontend.Models;
using Newtonsoft.Json;

namespace Frontend.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestPage : ContentPage
    {
        public TestPage()
        {
            InitializeComponent();
        }

        private async void send_request_Clicked(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://foodbookingapi.somee.com/api/GetProductById/1");
            string productList = await response.Content.ReadAsStringAsync();
            Console.WriteLine(productList);
            Product list = JsonConvert.DeserializeObject<Product>(productList);
            var statusCode = response.StatusCode;
            response_content.Text = $"Status code: {statusCode}\n"
                                    + $"Content: {list.Name}";
        }
    }
}