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
    public class OrderDetailController : ApiController
    {
        HttpResponseMessage response;
        Dictionary<string, object> param;

        [Route("api/AddOrderDetail")]
        [HttpPost]
        public HttpResponseMessage AddOrderDetail()
        {
            response = new HttpResponseMessage();
            try
            {
                string content = Request.Content.ReadAsStringAsync().Result;
                OrderDetails orderDetails = JsonConvert.DeserializeObject<OrderDetails>(content);

                param = null;
                param = new Dictionary<string, object>();
                param.Add(nameof(OrderDetails.AddressId), orderDetails.AddressId);
                param.Add(nameof(OrderDetails.UserId), orderDetails.UserId);
                param.Add(nameof(OrderDetails.Total), orderDetails.Total);
                param.Add(nameof(OrderDetails.CreatedDate), orderDetails.CreatedDate);
                param.Add(nameof(OrderDetails.ModifiedDate), orderDetails.ModifiedDate);

                int orderId = OrderDetailRepository.AddOrderDetail(param);
                if(orderId > 0)
                {
                    response.StatusCode = HttpStatusCode.OK;
                    response.Content = new StringContent(Convert.ToString(orderId));
                    
                }
                else
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Content = new StringContent(Convert.ToString(CheckedCode.UNKNOW_ERROR));
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

        [Route("api/GetOrderDetailByUserId/{UserId}")]
        [HttpGet]
        public HttpResponseMessage GetOrderDetailByUserId(int UserId)
        {
            response = new HttpResponseMessage();
            try
            {
                param = null;
                param = new Dictionary<string, object>();
                param.Add(nameof(OrderDetails.UserId), UserId);

                DataTable result = OrderDetailRepository.GetOrderDetailByUserId(param);
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
