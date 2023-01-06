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
using System.Net;
using System.Net.Http;

namespace FoodBookingAPI.Controllers
{
    public class UserController : ApiController
    {
        Dictionary<string, object> param;
        HttpResponseMessage response;
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
            if (originalHash.Length == newHash.Length)
            {
                while ((i < originalHash.Length) && (originalHash[i] == newHash[i]))
                {
                    i++;
                }
                if (i == originalHash.Length)
                {
                    return true;
                }
            }
            return false;
        }

        [Route("api/GetUserById/{UserId}")]
        [HttpGet]
        public HttpResponseMessage GetUserbyId(int UserId)
        {
            response = new HttpResponseMessage();
            try
            {
                param = null;
                param = new Dictionary<string, object>();
                param.Add(nameof(Users.UserId), UserId);
                DataTable result = UserRepository.GetUserById(param);

                if (result.Rows.Count > 0)
                {
                    response.StatusCode = HttpStatusCode.OK;
                    string jsonContent = JsonConvert.SerializeObject(result);
                    response.Content = new StringContent(jsonContent, UnicodeEncoding.UTF8, "application/json");
                }
                else
                {
                    // In case, No result returned to result variable
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.Content = new StringContent((Convert.ToString(CheckedCode.WRONG_ID)));
                }
                return response;
            }
            catch (Exception)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Content = new StringContent(Convert.ToString(CheckedCode.UNKNOW_ERROR));
                return response;
            }
        }

        [Route("api/AddUser")]
        [HttpPost]
        public HttpResponseMessage AddUser()
        {
            response = new HttpResponseMessage();
            try
            {
                string passString;
                string content;

                content = Request.Content.ReadAsStringAsync().Result;
                param = null;
                param = new Dictionary<string, object>();
                Debug.WriteLine(content);
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

                int check = UserRepository.AddUser(param);

                if (check == CheckedCode.EXISTED_USER)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Content = new StringContent(Convert.ToString(CheckedCode.EXISTED_USER));
                }
                else
                {
                    response.StatusCode = HttpStatusCode.OK;
                }
                return response;
            }
            catch (Exception)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Content = new StringContent(Convert.ToString(CheckedCode.UNKNOW_ERROR));
                return response;
            }
        }

        [Route("api/UpdateUser")]
        [HttpPost]
        public HttpResponseMessage UpdateUser()
        {
            response = new HttpResponseMessage();
            try
            {
                // Get  content of Post request
                string content = Request.Content.ReadAsStringAsync().Result;

                // Init param variable for add parameters
                param = null;
                param = new Dictionary<string, object>();

                // Convert from jsonContent to Users object
                Users updatedUser = JsonConvert.DeserializeObject<Users>(content);

                // Add parameter for get test user
                param.Add(nameof(Users.UserId), updatedUser.UserId);
                DataTable testUser = UserRepository.GetUserById(param);

                // Check the existence of User by UserId
                if(testUser.Rows.Count > 0)
                {
                    // Check the valid of Username
                   if(updatedUser.Username == testUser.Rows[0].Field<string>(nameof(Users.Username)))
                   {
                        string testPassword = testUser.Rows[0].Field<string>(nameof(Users.Password));
                        // Check password
                        if (CompareTwoHashValues(testPassword, updatedUser.Password) == true)
                        {
                            param = null;
                            param = new Dictionary<string, object>();

                            param.Add(nameof(Users.UserId), updatedUser.UserId);
                            param.Add(nameof(Users.Username), updatedUser.Username);
                            param.Add(nameof(Users.Password), updatedUser.Password);
                            param.Add(nameof(Users.FirstName), updatedUser.FirstName);
                            param.Add(nameof(Users.LastName), updatedUser.LastName);
                            param.Add(nameof(Users.Telephone), updatedUser.Telephone);
                            param.Add(nameof(Users.CreatedDate), updatedUser.CreatedDate);
                            param.Add(nameof(Users.ModifiedDate), updatedUser.ModifiedDate);
                            param.Add(nameof(Users.Logo), updatedUser.Logo);

                            int check = UserRepository.UpdateUser(param);

                            // Check the existence of Username
                            if (check == CheckedCode.EXISTED_USER)
                            {
                                response.StatusCode = HttpStatusCode.BadRequest;
                                response.Content = new StringContent(Convert.ToString(CheckedCode.EXISTED_USER));
                            }
                            else
                            {
                                response.StatusCode = HttpStatusCode.OK;
                            }
                        }
                        else
                        {
                            response.StatusCode = HttpStatusCode.BadRequest;
                            response.Content = new StringContent(Convert.ToString(CheckedCode.WRONG_PASSWORD));
                        }
                    }
                    else
                    {
                        response.StatusCode = HttpStatusCode.BadRequest;
                        response.Content = new StringContent(Convert.ToString(CheckedCode.WRONG_USERNAME));
                    }
                }
                else
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.Content = new StringContent(Convert.ToString(CheckedCode.WRONG_ID));
                }

                return response;
            }
            catch (Exception)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Content = new StringContent(Convert.ToString(CheckedCode.UNKNOW_ERROR));
                return response;
            }
        }

        [Route("api/Login")]
        [HttpPost]
        public HttpResponseMessage Login()
        {
            response = new HttpResponseMessage();
            try
            {
                // Get the content of Post request
                string content = Request.Content.ReadAsStringAsync().Result;

                // Convert content to Users object
                Users loginUser = JsonConvert.DeserializeObject<Users>(content);

                param = null;
                param = new Dictionary<string, object>();
                param.Add(nameof(Users.Username), loginUser.Username);

                DataTable testUser = UserRepository.GetUserByUsername(param);

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

                // Check the existence of User by Username
                if (testUser.Rows.Count > 0)
                {
                    string testPassword = testUser.Rows[0].Field<string>(testUser.Columns["Password"]);
                    string newHashPassword = ConvertStringToHashPassword(loginUser.Password);
                    bool check = CompareTwoHashValues(testPassword, newHashPassword);
                   
                    // Check Password
                    if (check == true)
                    {
                        response.StatusCode = HttpStatusCode.OK;
                        response.Content = new StringContent(nameof(Users.UserId));
                    }
                    else
                    {
                        response.StatusCode = HttpStatusCode.BadRequest;
                        response.Content = new StringContent(Convert.ToString(CheckedCode.WRONG_PASSWORD));
                    }
                }
                else
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.Content = new StringContent(Convert.ToString(CheckedCode.WRONG_USERNAME));
                }
                return response;
            }
            catch (Exception)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Content = new StringContent(Convert.ToString(CheckedCode.UNKNOW_ERROR));
                return response;
            }
        }
    }
}