﻿using Frontend.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace Frontend.Services
{
    public static class ProductService
    {

        //static List<Product> products;
        static ProductService()
        {
            //initialize();
        }

        //static async void initialize()
        //{
        //    HttpResponseMessage response = await Base.client.GetAsync("api/GetAllProducts");
        //    string productList = response.Content.ReadAsStringAsync().Result;
        //    Debug.WriteLine("Product list: " + productList);
        //    //var productList = await client.GetStringAsync("api/GetAllProduct");
        //    products = JsonConvert.DeserializeObject<List<Product>>(productList);
        //}
        public static async Task<List<Product>> GetAllProduct()
        {
            try
            {
                HttpResponseMessage response = await Base.client.GetAsync("api/GetAllProducts");
                string productList = response.Content.ReadAsStringAsync().Result;
                Debug.WriteLine("Product list: " + productList);
                //var productList = await client.GetStringAsync("api/GetAllProduct");
                List<Product> productListConverted = JsonConvert.DeserializeObject<List<Product>>(productList);
                return productListConverted;
                //return await Task.FromResult(products);
            }
            catch (Exception e)
            {
                Debug.WriteLine("error while calling api: " + e);
                throw e;
            }
        }
        public static async Task<Product> GetProductByProductId(int ProductId)
        {
            try
            {
                var product = await Base.client.GetStringAsync("api/GetProductByID/" + ProductId);
                Product productConverted = JsonConvert.DeserializeObject<List<Product>>(product)[0];
                return productConverted;
                //return await Task.FromResult(products.Find((product) => product.ProductId == ProductId));
            }
            catch (Exception e)
            {
                Debug.WriteLine("error while calling api: " + e);
                throw e;
            }
        }
    }
}
