using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using FoodBookingAPI.Models;
using FoodBookingAPI.Repository;
using Newtonsoft.Json;

namespace FoodBookingAPI.Controllers
{
    public class BlogController : ApiController
    {
        Dictionary<string, object> param;
        HttpResponseMessage response;

        [Route("api/GetAllBlogs")]
        [HttpGet]
        public HttpResponseMessage GetAllBlogs()
        {
            response = new HttpResponseMessage();
            try
            {
                DataTable result = BlogRepository.GetAllBlogs();
                if(result != null)
                {
                    response.StatusCode = HttpStatusCode.OK;
                    string jsonContent = JsonConvert.SerializeObject(result);
                    response.Content = new StringContent(jsonContent);
                }
                else
                {
                    response.StatusCode = HttpStatusCode.NotFound;
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
