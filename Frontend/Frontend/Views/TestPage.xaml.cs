using Frontend.Models;
using Frontend.Services;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net;
using System.Diagnostics;
using System.Text.RegularExpressions;

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
                UserId = 3,
                Username = "Username_2",
                FirstName = "Văn B",
                LastName = "Nguyễn",
                Telephone = "0123454321",
                Logo = "logo.png",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                Password = "12345"
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

            var obj = new
            {
                UserId = 4,
                oldPassword = "12345",
                newPassword = "uit"
            };

            //var json = JsonConvert.SerializeObject(UserService.user);
            //var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json"); // use MediaTypeNames.Application.Json in Core 3.0+ and Standard 2.1+
            //HttpResponseMessage response = await Base.client.PostAsync("api/AddUser",stringContent);
            //var statusCode = response.StatusCode;

            //string content = response.Content.ReadAsStringAsync().Result;
            //if (statusCode == HttpStatusCode.OK)
            //{
            //    response_content.Text = $"Status code: {statusCode}";
            //}
            //else
            //{
            //    response_content.Text = $"Status code: {statusCode}\n"
            //        + $"Content: {content}\n"
            //        + $"Content: {int.Parse(content) + 5 == (int)20}";

            //}
            var input = "P@ssw0rd";

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum8Chars = new Regex(@".{8,}");

            var isValidated = hasNumber.IsMatch(input) && hasUpperChar.IsMatch(input) && hasMinimum8Chars.IsMatch(input);
            Console.WriteLine(isValidated);
        }
    }
}