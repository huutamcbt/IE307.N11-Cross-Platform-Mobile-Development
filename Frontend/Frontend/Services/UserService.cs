using Frontend.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
                Firstname = "Nguyễn Văn",
                Lastname = "A",
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
                return Task.FromResult(-1);
                throw e;
            }
        }
    }
}
