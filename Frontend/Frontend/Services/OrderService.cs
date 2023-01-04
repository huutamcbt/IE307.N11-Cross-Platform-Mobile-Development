using Frontend.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Frontend.Services
{
    public static class OrderService
    {
        //fake orderDetail
        static List<OrderDetail> orderDetails;
        static List<OrderItem> OrderItems;

        static OrderService()
        {
            orderDetails = new List<OrderDetail>();
            orderDetails.Add(new OrderDetail { OrderId = 1, PaymentId = 1, Total = 134654, UserId = 1 });
            orderDetails.Add(new OrderDetail { OrderId = 1, PaymentId = 1, Total = 134654, UserId = 1 });
            orderDetails.Add(new OrderDetail { OrderId = 1, PaymentId = 1, Total = 134654, UserId = 1 });

            OrderItems = new List<OrderItem>();
            //OrderItems.Add(new OrderItem { })
        }
        public static async Task<HttpResponseMessage> PlaceOrder(List<OrderItem> orderItems, double Total)
        {
            try
            {
                ////send a request to create order
                //OrderDetail orderDetail = new OrderDetail { Total = Total, UserId = UserService.GetUserID() };
                //var orderStringContent = new StringContent(
                //    JsonConvert.SerializeObject(orderDetail), 
                //    UnicodeEncoding.UTF8, "application/json");
                //var firstResponse = await Base.client.PostAsync("api/CreateOrder", orderStringContent);


                ////case can't create order
                //if (!firstResponse.IsSuccessStatusCode) {
                //    return firstResponse;   
                //}

                ////first reponse content return order Id

                ////create orderitems
                //var orderItemsStringContent = new StringContent(
                //    JsonConvert.SerializeObject(orderItems), 
                //    UnicodeEncoding.UTF8, "application/json");
                //var secondResponse = await Base.client.PostAsync(
                //    "api/CreateOrderItems/" + firstResponse.Content.ReadAsStringAsync(),
                //    orderItemsStringContent);

                //return secondResponse;

                await Task.FromResult(1);
                var response = new HttpResponseMessage { StatusCode = System.Net.HttpStatusCode.OK };
                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        public static async Task<List<OrderDetail>> getOrderDetail()
        {
            try
            {
                var orderDetail = await Base.client.GetStringAsync("api/getOrderDetailByUserId/" + UserService.GetUserID());
                List<OrderDetail> orderDetailConverted = JsonConvert.DeserializeObject<List<OrderDetail>>(orderDetail);
                return orderDetailConverted;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task<HttpResponseMessage> RemoveItem(Product product)
        {
            try
            {
                //HttpResponseMessage response = await Base.client
                //    .DeleteAsync($"api/DeleteCartItems?productId{product.ProductId}&sessionId{UserService.GetSessionID()}");
                //return response;


                return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static async Task<HttpResponseMessage> UpdateItem(Product product)
        {
            try
            {
                //CartItem cartItem = new CartItem
                //{
                //    SessionId = UserService.GetSessionID(),
                //    ProuductId = product.ProductId,
                //    Quantity = product.Quantity,
                //    ModifiedDate = new DateTime()
                //};
                //var json = JsonConvert.SerializeObject(cartItem);
                //var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json"); // use MediaTypeNames.Application.Json in Core 3.0+ and Standard 2.1+
                //var response = await Base.client.PostAsync("api/AddToCart", stringContent);
                //return response;


                return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
