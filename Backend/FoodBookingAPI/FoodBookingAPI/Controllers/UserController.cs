using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;
using FoodBookingAPI.Models;
using FoodBookingAPI.Repository;
using Newtonsoft.Json;

namespace FoodBookingAPI.Controllers
{
    public class UserController : ApiController
    {
        Dictionary<string, object> param;

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

        [Route("api/UpdateUser")]
        [HttpPost]
        public IHttpActionResult UpdateUser()
        {
            try
            {
                param = null;
                param = new Dictionary<string, object>();

                string content = Request.Content.ReadAsStringAsync().Result;

                string jsonContent = "[" + content + "]";

                Users updatedUser = JsonConvert.DeserializeObject<List<Users>>(jsonContent)[0];

                param.Add(nameof(Users.UserId), updatedUser.UserId);
                param.Add(nameof(Users.Username), updatedUser.Username);
                param.Add(nameof(Users.Password), updatedUser.Password);
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
    }
}