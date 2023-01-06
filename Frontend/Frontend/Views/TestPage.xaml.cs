using Frontend.Models;
using Frontend.Services;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net;

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
          
            User user = new User
            {
                UserId = 5,
                Username = "Username_1",
                FirstName = "Văn B",
                LastName = "Nguyễn",
                Telephone = "0123456789",
                Logo = "logo.png",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                Password = "Username@12"
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
                ReviewId = 1,
                ProductId = 5,
                Rating = 5,
                UserId = 1,
                Content = "Sản phẩm chất lượng tốt, giao hàng nhanh",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                DeletedDate = DateTime.Now
            };
            

            CartItem cartItem = new CartItem
            {
                CartItemId = 2,
                SessionId = 1,
                ProductId = 1,
                Quantity = 200,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var json = JsonConvert.SerializeObject(user);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json"); // use MediaTypeNames.Application.Json in Core 3.0+ and Standard 2.1+
            HttpResponseMessage response = await Base.client.GetAsync("api/GetUserById/"+ user.UserId);
            var statusCode = response.StatusCode;

            string content = response.Content.ReadAsStringAsync().Result;
            response_content.Text = $"Status code: {statusCode}\n"
                + $"Content: {content}\n"
                + $"Content: {int.Parse(content) +5 == (int)20}";
        }
    }
}