using Frontend.Models;
using Frontend.Services;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
            //HttpClient client = new HttpClient();
            //HttpResponseMessage response = await client.GetAsync("http://foodbookingapi.somee.com/api/GetAllProduct");
            //string productList = await response.Content.ReadAsStringAsync();
            //Console.WriteLine(productList);
            //Product list = JsonConvert.DeserializeObject<Product>(productList);
            User user = new User
            {
                UserId = 1,
                Username = "Username_1",
                Firstname = "Văn C",
                Lastname = "Nguyễn",
                Telephone = "0123456789",
                Logo = "logo.png",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            UserAddress address = new UserAddress
            {
                AddressId = 2,
                UserId = 1,
                Address = "abc",
                District = "def",
                Province = "province",
                City = "Đà Nẵng City",
                Country = "Việt Nam",
                Mobile = "0123456789"
            };

            Review review = new Review
            {
                ReviewID = 1,
                ProductID = 5,
                Rating = 5,
                UserID = 1,
                Content = "Sản phẩm chất lượng tốt, giao hàng nhanh",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                DeletedDate = DateTime.Now
            };


            var json = JsonConvert.SerializeObject(review);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json"); // use MediaTypeNames.Application.Json in Core 3.0+ and Standard 2.1+
            HttpResponseMessage response = await Base.client.DeleteAsync("api/DeleteReview/" + review.ReviewID);
            var statusCode = response.StatusCode;

            string content = response.Content.ReadAsStringAsync().Result.Replace("\\", "");
            response_content.Text = $"Status code: {statusCode}\n"
                + $"Content: {content}";
        }
    }
}