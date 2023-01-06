using Frontend.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Services
{
    public static class UserService
    {
        //save user info after login
        static User user;
        static ShoppingSession shoppingSession;
        static UserService()
        {

            //user = new User
            //{
            //    UserId = 1,
            //    Username = "toinomon",
            //    FirstName = "Nguyễn Văn",
            //    LastName = "A",
            //    Telephone = "0654986587",
            //    Logo = "profile.webp",
            //    CreatedDate = new DateTime(),
            //    ModifiedDate = new DateTime()
            //};

            //shoppingSession = new ShoppingSession { SessionId = 1, Total = 2, UserId = 1 };

        }

        public static async Task<User> GetUserById(int UserId)
        {
            try
            {
                var userRequest = await Base.client.GetStringAsync("api/GetUserById/" + UserId);
                User _user = JsonConvert.DeserializeObject<List<User>>(userRequest)[0];
                return _user; 
                //var sessionRequest = await Base.client.GetStringAsync("api/getShoppingSessionByUserId/" + user.UserId);
                //shoppingSession = JsonConvert.DeserializeObject<List<ShoppingSession>>(sessionRequest)[0];
            }
            catch (Exception e)
            { throw e; }
        }
        //Called after logging in
        public static async Task InitializeShoppingSession(string UserId)
        {
            try
            {
                var userRequest = await Base.client.GetStringAsync("api/GetUserById/" + UserId);
                user = JsonConvert.DeserializeObject<List<User>>(userRequest)[0];
                //var sessionRequest = await Base.client.GetStringAsync("api/getShoppingSessionByUserId/" + user.UserId);
                //shoppingSession = JsonConvert.DeserializeObject<List<ShoppingSession>>(sessionRequest)[0];
            }
            catch (Exception e)
            { throw e; }
        }
        public static Task<User> GetUser()
        {
            try
            {
                return Task.FromResult<User>(user);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static int GetUserId()
        {
            return user.UserId;
        }
        public static int GetSessionID()
        {
            return shoppingSession.SessionId;
        }
        public async static Task<HttpResponseMessage> UpdateUser(User _user)
        {
            try
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(_user), UnicodeEncoding.UTF8, "application/json");
                var result = await Base.client.PostAsync("/api/UpdateUser", stringContent);
                if (result.IsSuccessStatusCode)
                {
                    user = _user;
                }
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static async Task<HttpResponseMessage> Login(User _user)
        {
            try
            {
                var stringContent= new StringContent(JsonConvert.SerializeObject(_user), UnicodeEncoding.UTF8, "application/json");
                var result = await Base.client.PostAsync("/api/Login", stringContent);
                if (result.IsSuccessStatusCode)
                {
                    var UserId = await result.Content.ReadAsStringAsync();

                    await InitializeShoppingSession( UserId);
                    App.isLogin = true;
                }
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static async Task<HttpResponseMessage> AddUser(User _user)
        {
            try
            {
                var json = JsonConvert.SerializeObject(_user);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var result = await Base.client.PostAsync("/api/AddUser", stringContent);
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
