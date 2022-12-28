using System;
using System.Collections.Generic;
using System.Text;
using Frontend.Models;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Essentials;
using System.Diagnostics;

namespace Frontend.Services
{
    public static class ProductService
    {
        static string BaseURL = "http://foodbookingapi.somee.com";
        static HttpClient client;

        static ProductService()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri(BaseURL)
            };
        }


        public static async Task<List<Product>> GetAllProduct()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("api/GetAllProduct");
                string productList = await response.Content.ReadAsStringAsync();
                //var productList = await client.GetStringAsync("api/GetAllProduct");
                List<Product> productListConverted = JsonConvert.DeserializeObject<List<Product>>(productList);
                return productListConverted;
            }
            catch (Exception e)
            {
                Debug.WriteLine("error while calling api: " + e);
                throw e;
            }
        }
        public static async Task<Product> GetProductByProductID(int productID)
        {
            try
            {
                var product = await client.GetStringAsync("api/GetProductByID/" + productID);
                Product productConverted = JsonConvert.DeserializeObject<List<Product>>(product)[0];
                return productConverted;
            }
            catch (Exception e)
            {
                Debug.WriteLine("error while calling api: " + e);
                throw e;
            }
        }
    }
}
