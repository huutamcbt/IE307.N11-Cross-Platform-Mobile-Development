﻿using Frontend.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Services
{
    public static class CartService
    {
        static List<Product> cartItems;
        static CartService()
        {
            //
            cartItems = new List<Product>();
            //Task.Delay(5000).ContinueWith((task) => {
            initializeCart();
        //});
            //cartItems.Add(new Product { CategoryID = 1, Image = "chart.png", Name = "abc", Price = 654118, Quantity = 2, ProductId = 1, Stock = 45, Description = "sfvfsd" });
            //cartItems.Add(new Product { CategoryID = 1, Image = "chart.png", Name = "abc", Price = 654118, Quantity = 2, ProductId = 2, Stock = 45, Description = "sfvfsd" });
            //cartItems.Add(new Product { CategoryID = 1, Image = "chart.png", Name = "abc", Price = 65418, Quantity = 2, ProductId = 3, Stock = 45, Description = "sfvfsd" });
            //cartItems.Add(new Product { CategoryID = 1, Image = "chart.png", Name = "abc", Price = 64118, Quantity = 2, ProductId = 4, Stock = 45, Description = "sfvfsd" });

        }
        public static async void initializeCart()
        {
            //string json = await Base.client.GetStringAsync("api/GetCartItemBySessionId/1");
            //List<CartItem> carts = JsonConvert.DeserializeObject<List<CartItem>>(json);
            //foreach(CartItem cartItem in carts)
            //{
            //    Product product = await ProductService.GetProductByProductId(cartItem.ProductId);
            //    product.Quantity = cartItem.Quantity;
            //    cartItems.Add(product);
            //}
        }
        public static async Task<HttpResponseMessage> AddToCart(Product product)
        {
            try
            {
                CartItem cartItem = new CartItem
                {
                    SessionId = 1,
                    ProductId = product.ProductId,
                    Quantity = product.Quantity,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now

                };
                //var json = JsonConvert.SerializeObject(cartItem);
                //var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json"); // use MediaTypeNames.Application.Json in Core 3.0+ and Standard 2.1+
                //var response = await Base.client.PostAsync("api/AddToCart", stringContent);

                ////await Task.FromResult(1);
                //if (response.IsSuccessStatusCode)
                    cartItems.Add(product);
                var response = new HttpResponseMessage { StatusCode = System.Net.HttpStatusCode.OK };
                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        public static async Task<List<Product>> getCartItem()
        {
            try
            {

                //var cartItems = await Base.client.GetStringAsync("api/getCartItemBySessionID/" + UserService.GetSessionID());
                //List<Product> cartItemsConverted = JsonConvert.DeserializeObject<List<Product>>(cartItems);
                //return cartItemsConverted;

                return await Task.FromResult(cartItems);

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
                //    .DeleteAsync($"api/DeleteCartItems?ProductId{product.ProductId}&sessionId{UserService.GetSessionID()}");
                //return response;

                await Task.FromResult(1);
                cartItems.Remove(product);
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
                //    ProductId = product.ProductId,
                //    Quantity = product.Quantity,
                //    ModifiedDate = new DateTime()
                //};
                //var json = JsonConvert.SerializeObject(cartItem);
                //var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json"); // use MediaTypeNames.Application.Json in Core 3.0+ and Standard 2.1+
                //var response = await Base.client.PostAsync("api/AddToCart", stringContent);
                //return response;

                int index = cartItems.FindIndex((e) => e.ProductId == product.ProductId);
                cartItems[index] = product;
                await Task.FromResult(1);
                return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
