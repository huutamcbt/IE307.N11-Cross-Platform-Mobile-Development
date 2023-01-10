using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using FoodBookingAPI.Models;
using FoodBookingAPI.Repository;
using Newtonsoft.Json;

namespace FoodBookingAPI.Controllers
{
    public class OrderItemController : ApiController
    {
        Dictionary<string, object> param;
        HttpResponseMessage response;

        [Route("api/AddOrderItem")]
        [HttpPost]
        public HttpResponseMessage AddOrderItem()
        {
            response = new HttpResponseMessage();
            try
            {
                string content = Request.Content.ReadAsStringAsync().Result;
                List<OrderItems> orderItemList = JsonConvert.DeserializeObject<List<OrderItems>>(content);
                int count = 0;
                foreach (OrderItems orderItems in orderItemList )
                {
                    param = null;
                    param = new Dictionary<string, object>();
                    param.Add(nameof(OrderItems.OrderId), orderItems.OrderId);
                    param.Add(nameof(OrderItems.ProductId), orderItems.ProductId);
                    param.Add(nameof(OrderItems.Quantity), orderItems.Quantity);
                    param.Add(nameof(OrderItems.CreatedDate), orderItems.CreatedDate);
                    param.Add(nameof(OrderItems.ModifiedDate), orderItems.ModifiedDate);

                    int OrderItemId = OrderItemRepository.AddOrderItem(param);

                    if (OrderItemId > 0)
                        count++;
                }
                
                if (count == orderItemList.Count)
                {
                    response.StatusCode = HttpStatusCode.OK;
                    response.Content = new StringContent(Convert.ToString(orderItemList[0].OrderId));
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
    }
}
