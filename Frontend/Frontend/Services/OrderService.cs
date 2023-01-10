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
        static List<OrderItem> orderItems;

        static OrderService()
        {
            orderDetails = new List<OrderDetail>();
            orderDetails.Add(new OrderDetail { OrderId = 1,  Total = 134654, UserId = 1,CreatedDate = DateTime.Now, ModifiedDate= DateTime.Now });
            orderDetails.Add(new OrderDetail { OrderId = 1, Total = 134654, UserId = 1, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now });
            orderDetails.Add(new OrderDetail { OrderId = 1, Total = 134654, UserId = 1, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now });

            orderItems = new List<OrderItem>();
            orderItems.Add(new OrderItem { OrderId = 1, OrderItemId = 1, ProductId = 1, Quantity = 3 });
            orderItems.Add(new OrderItem { OrderId = 1, OrderItemId = 1, ProductId = 1, Quantity = 3 });
            orderItems.Add(new OrderItem { OrderId = 1, OrderItemId = 1, ProductId = 1, Quantity = 3 });
        }
        public static async Task<HttpResponseMessage> PlaceOrder(List<OrderItem> orderItems, double Total,int AddressId)
        {
            try
            {
                ////send a request to create order
                //OrderDetail orderDetail = new OrderDetail { Total = Total, UserId = UserService.GetUserId(),AddressId = AddressId };
                //var orderStringContent = new StringContent(
                //    JsonConvert.SerializeObject(orderDetail),
                //    UnicodeEncoding.UTF8, "application/json");
                //var firstResponse = await Base.client.PostAsync("api/CreateOrder", orderStringContent);


                ////case can't create order
                //if (!firstResponse.IsSuccessStatusCode)
                //{
                //    return firstResponse;
                //}

                //String orderId = await firstResponse.Content.ReadAsStringAsync();
                ////first reponse content return order Id
                //foreach(OrderItem orderItem in orderItems)
                //{
                //    orderItem.OrderId = Int32.Parse(orderId);
                //}

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



        public static async Task<List<OrderDetail>> GetOrderDetail()
        {
            try
            {
                //var orderDetail = await Base.client.GetStringAsync("api/GetOrderDetailByUserId/" + UserService.GetUserId());
                //List<OrderDetail> orderDetailConverted = JsonConvert.DeserializeObject<List<OrderDetail>>(orderDetail);
                //return orderDetailConverted;


                return await Task.FromResult(orderDetails);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task<List<OrderItem>> GetOrderItemsByOrderId(int orderId)
        {
            try
            {
                //var orderItem = await Base.client.GetStringAsync("api/GetOrderItemsByOrderId/" + orderId);
                //List<OrderItem> orderItemsConverted = JsonConvert.DeserializeObject<List<OrderItem>>(orderDetail);
                //return orderItemsConverted;


                return await Task.FromResult(orderItems);
            }
            catch (Exception e)
            {
                throw e;
            }
        }




        // unuse
        //public static async Task<HttpResponseMessage> RemoveItem(Product product)
        //{
        //    try
        //    {
        //        //HttpResponseMessage response = await Base.client
        //        //    .DeleteAsync($"api/DeleteCartItems?ProductId{product.ProductId}&sessionId{UserService.GetSessionID()}");
        //        //return response;

        //        await Task.FromResult(1);
        //        return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}
        //public static async Task<HttpResponseMessage> UpdateItem(Product product)
        //{
        //    try
        //    {
        //        //CartItem cartItem = new CartItem
        //        //{
        //        //    SessionId = UserService.GetSessionID(),
        //        //    ProuductId = product.ProductId,
        //        //    Quantity = product.Quantity,
        //        //    ModifiedDate = new DateTime()
        //        //};
        //        //var json = JsonConvert.SerializeObject(cartItem);
        //        //var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json"); // use MediaTypeNames.Application.Json in Core 3.0+ and Standard 2.1+
        //        //var response = await Base.client.PostAsync("api/AddToCart", stringContent);
        //        //return response;

        //        await Task.FromResult(1);
        //        return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}
    }
}
