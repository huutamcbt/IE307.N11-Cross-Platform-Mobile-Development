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

            user = new User
            {
                UserId = 1,
                Username = "toinomon",
                FirstName = "Nguyễn Văn",
                LastName = "A",
                Telephone = "0654986587",
                Logo = "profile.webp",
                CreatedDate = new DateTime(),
                ModifiedDate = new DateTime()
            };

            shoppingSession = new ShoppingSession { SessionId = 1, Total = 2, UserId = 1 };

        }

        //Called after logging in
        public static async Task InitializeShoppingSession(int userId)
        {
            try
            {
                //var userRequest = await Base.client.GetStringAsync("api/getUserById/" + userId);
                //user = JsonConvert.DeserializeObject<User>(userRequest);
                var sessionRequest = await Base.client.GetStringAsync("api/getShoppingSessionByUserId/" + user.UserId);
                shoppingSession = JsonConvert.DeserializeObject<List<ShoppingSession>>(sessionRequest)[0];
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
        public static int GetUserID()
        {
            return user.UserId;
        }
        public static int GetSessionID()
        {
            return shoppingSession.SessionId;
        }
        public static Task<int> UpdateUser(User _user)
        {
            try
            {
                user = _user;
                return Task.FromResult(1);
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

                    //await InitializeShoppingSession(int userId);
                }
                App.isLogin = true;
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
