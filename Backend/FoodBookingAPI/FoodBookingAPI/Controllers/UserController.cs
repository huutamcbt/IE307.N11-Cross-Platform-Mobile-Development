using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Security.Cryptography;
using System.Text;
using FoodBookingAPI.Models;
using FoodBookingAPI.Repository;
using Newtonsoft.Json;
using System.Diagnostics;

namespace FoodBookingAPI.Controllers
{
    public class UserController : ApiController
    {
        Dictionary<string, object> param;

        [NonAction]
        private string ConvertStringToHashPassword(string clearTextPassword)
        {
            string sSourceData;
            byte[] tmpSource;
            byte[] tmpHash;

            // Assign user clear text password to sSourceData variable
            sSourceData = clearTextPassword;

            // Create a  byte array from source data
            tmpSource = ASCIIEncoding.ASCII.GetBytes(sSourceData);

            // Compute hash based on source data
            tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);

            // Convert Hash byte array to a hexadecimal string
            StringBuilder sOuput = new StringBuilder(tmpHash.Length);
            for (int i = 0; i < tmpHash.Length; i++)
            {
                sOuput.Append(tmpHash[i].ToString("X2"));
            }
            return sOuput.ToString();
        }

        [NonAction]
        private bool CompareTwoHashValues(string originalHash, string newHash)
        {
            int i = 0;
            if(originalHash.Length == newHash.Length)
            {
                while((i< originalHash.Length) && (originalHash[i] == newHash[i]))
                {
                    i++;
                }
                if(i == originalHash.Length)
                {
                    return true;
                }
            }
            return false;
        }

        [Route("api/GetUserById/{UserId}")]
        [HttpGet]
        public IHttpActionResult GetUserbyId(int UserId)
        {
            try
            {
                param = null;
                param = new Dictionary<string, object>();
                param.Add(nameof(Users.UserId), UserId);
                DataTable result = UserRepository.GetUserById(param);

                return Ok(result);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [Route("api/AddUser")]
        [HttpPost]
        public IHttpActionResult AddUser()
        {
            try
            {
                string passString;
                string content;
                
                content = Request.Content.ReadAsStringAsync().Result;
                param = null;
                param = new Dictionary<string, object>();

                Users newUser = JsonConvert.DeserializeObject<Users>(content);
                
                // Convert original password to hexadicimal string password
                passString = ConvertStringToHashPassword(newUser.Password);
                
                param.Add(nameof(Users.Username), newUser.Username);
                param.Add(nameof(Users.Password), passString);
                param.Add(nameof(Users.FirstName), newUser.FirstName);
                param.Add(nameof(Users.LastName), newUser.LastName);
                param.Add(nameof(Users.Telephone), newUser.Telephone);
                param.Add(nameof(Users.CreatedDate), newUser.CreatedDate);
                param.Add(nameof(Users.ModifiedDate), newUser.ModifiedDate);
                param.Add(nameof(Users.Logo), newUser.Logo);
                
                bool success = UserRepository.AddUser(param);
               
                if (success == true)
                    return Ok();
                return NotFound();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [Route("api/UpdateUser")]
        [HttpPost]
        public IHttpActionResult UpdateUser()
        {
            try
            {
                string content = Request.Content.ReadAsStringAsync().Result;
                param = null;
                param = new Dictionary<string, object>();
                Users updatedUser = JsonConvert.DeserializeObject<Users>(content);
                string passString = ConvertStringToHashPassword(updatedUser.Password);


                param.Add(nameof(Users.UserId), updatedUser.UserId);
                param.Add(nameof(Users.Username), updatedUser.Username);
                param.Add(nameof(Users.Password), passString);
                param.Add(nameof(Users.FirstName), updatedUser.FirstName);
                param.Add(nameof(Users.LastName), updatedUser.LastName);
                param.Add(nameof(Users.Telephone), updatedUser.Telephone);
                param.Add(nameof(Users.CreatedDate), updatedUser.CreatedDate);
                param.Add(nameof(Users.ModifiedDate), updatedUser.ModifiedDate);
                param.Add(nameof(Users.Logo), updatedUser.Logo);

                bool success = UserRepository.UpdateUser(param);

                if (success == true)
                    return Ok();
                return NotFound();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [Route("api/Login")]
        [HttpPost]
        public IHttpActionResult Login()
        {
            try
            {
                string content = Request.Content.ReadAsStringAsync().Result;

                Users loginUser = JsonConvert.DeserializeObject<Users>(content);
                param = null;
                param = new Dictionary<string, object>();
                param.Add(nameof(Users.UserId), loginUser.UserId);
                DataTable testUser = UserRepository.GetUserById(param);

                // Convert Datatable to object list ///////////
                //DataTable tableUsers = UserRepository.GetUserById(param);
                //var userList = (from rw in tableUsers.AsEnumerable()
                //                select new Users()
                //                {
                //                    UserId = Convert.ToInt32(rw["UserId"]),
                //                    Username = Convert.ToString(rw["Username"]),
                //                    Password = Convert.ToString(rw["Password"]),
                //                    FirstName = Convert.ToString(rw["FirstName"]),
                //                    LastName = Convert.ToString(rw["LastName"]),
                //                    Telephone = Convert.ToString(rw["Telephone"]),
                //                    CreatedDate = Convert.ToDateTime(rw["CreatedDate"]),
                //                    ModifiedDate = Convert.ToDateTime(rw["ModifiedDate"]),
                //                    Logo = Convert.ToString(rw["Logo"])
                //                }).ToList();
                //////////////////////////////////////////////

                // Get the user match with the login user id
                //Users matchedUser = userList[0];
                //tableUsers.Rows[0].Field<string>(tableUsers.Columns["Pasword"]);

                string testPassword = testUser.Rows[0].Field<string>(testUser.Columns["Password"]);
                string newHashPassword = ConvertStringToHashPassword(loginUser.Password);
                bool check = CompareTwoHashValues(testPassword, newHashPassword);
                Debug.WriteLine("Login");
                if (check == true)
                    return Ok();
                return NotFound();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}