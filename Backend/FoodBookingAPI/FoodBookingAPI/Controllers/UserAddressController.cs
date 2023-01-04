using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using FoodBookingAPI.Models;
using Newtonsoft.Json;


using FoodBookingAPI.Repository;
using System.Data;

namespace FoodBookingAPI.Controllers
{
    public class UserAddressController : ApiController
    {
        Dictionary<string, object> param;

        [Route("api/GetAddressesByUserId/{UserId}")]
        [HttpGet]
        public IHttpActionResult GetAddressByUserId(int UserId)
        {
            try
            {
                param.Add(nameof(UserAddresss.UserId), UserId);
                DataTable dataTable = UserAddressRepository.GetAddressesByUserId(param);

                return Ok(dataTable);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [Route("api/AddAddress")]
        [HttpPost]
        public IHttpActionResult AddAddress()
        {
            try
            {
                param = null;
                param = new Dictionary<string, object>();
                // Get content of post request body
                string content = Request.Content.ReadAsStringAsync().Result;
         
                UserAddresss userAddresss = JsonConvert.DeserializeObject<UserAddresss>(content);

                //param.Add(nameof(UserAddresss.AddressId), userAddresss.AddressId);
                param.Add(nameof(UserAddresss.Address), userAddresss.Address);
                param.Add(nameof(UserAddresss.City), userAddresss.City);
                param.Add(nameof(UserAddresss.Country), userAddresss.Country);
                param.Add(nameof(UserAddresss.District), userAddresss.District);
                param.Add(nameof(UserAddresss.Mobile), userAddresss.Mobile);
                param.Add(nameof(UserAddresss.Province), userAddresss.Province);
                param.Add(nameof(UserAddresss.UserId), userAddresss.UserId);
                
                bool success = UserAddressRepository.AddAddress(param);
                if (success == true)
                    return Ok();
                return NotFound();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [Route("api/UpdateAddress")]
        [HttpPost]
        public IHttpActionResult UpdateAddress()
        {
            try
            {
                param = null;
                param = new Dictionary<string, object>();
                // Get content of post body and replace \ character empty character
                string content = Request.Content.ReadAsStringAsync().Result;

                // Convert json object to UserAddress object
                UserAddresss userAddresss = JsonConvert.DeserializeObject<UserAddresss>(content);

                param.Add(nameof(UserAddresss.AddressId), userAddresss.AddressId);
                param.Add(nameof(UserAddresss.Address), userAddresss.Address);
                param.Add(nameof(UserAddresss.City), userAddresss.City);
                param.Add(nameof(UserAddresss.Country), userAddresss.Country);
                param.Add(nameof(UserAddresss.District), userAddresss.District);
                param.Add(nameof(UserAddresss.Mobile), userAddresss.Mobile);
                param.Add(nameof(UserAddresss.Province), userAddresss.Province);
                param.Add(nameof(UserAddresss.UserId), userAddresss.UserId);

                bool success = UserAddressRepository.UpdateAddress(param);

                if (success == true)
                    return Ok();
                else
                    return NotFound();

            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [Route("api/DeleteAddress/{AddressId}")]
        [HttpDelete]
        public IHttpActionResult DeleteAddress(int AddressId)
        {
            try
            {
                param = null;
                param = new Dictionary<string, object>();
                Debug.WriteLine("Delete Method");
                param.Add(nameof(UserAddresss.AddressId), AddressId);

                bool success = UserAddressRepository.DeleteAddress(param);
                if (success == true)
                    return Ok("OK");
                return NotFound();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}