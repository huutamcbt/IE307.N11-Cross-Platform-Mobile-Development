using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Services
{
    public static class UserService
    {
        static User user;
        static UserService()
        {
            user = new User { 
                UserId = 1, 
                Username = "toinomon", 
                Firstname = "Nguyễn Văn", Lastname = "A", 
                Telephone = "0654986587", 
                Logo = "profile.webp", 
                CreatedDate = new DateTime(), ModifiedDate = new DateTime() };
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
