using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Frontend.Models;
using Newtonsoft.Json;
using Frontend.Services;
using System.Diagnostics;
using System.IO;

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
                UserId = 1,
                Username = "Username_1",
                Firstname = "Văn B",
                Lastname = "Nguyễn",
                Telephone = "0123456789",
                Logo = "logo.png",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                Password = "Username@12345"
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


            var json = JsonConvert.SerializeObject(user);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json"); // use MediaTypeNames.Application.Json in Core 3.0+ and Standard 2.1+
            HttpResponseMessage response = await Base.client.PostAsync("api/Login/",stringContent);
            var statusCode = response.StatusCode;

            string content = response.Content.ReadAsStringAsync().Result.Replace("\\", "");
            response_content.Text = $"Status code: {statusCode}\n"
                + $"Content: {content}";
        }
    }
}