using System;
using System.Collections.Generic;
using System.Text;
using Frontend.Models;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace Frontend.Services
{
    public class ProductService
    {
        public ProductService()
        {

        }


        public async Task<List<Product>> GetAllProduct()
        {
            HttpClient httpClient = new HttpClient();
            var productList = await httpClient.GetStringAsync("http://foodbookingapi.somee.com/api/GetAllProduct");
            List<Product> productListConverted = JsonConvert.DeserializeObject<List<Product>>(productList);
            return await Task.FromResult(productListConverted);
        }
        public async Task<Product> GetProductByProductID(int productID)
        {
            HttpClient httpClient = new HttpClient();
            var product = await httpClient.GetStringAsync("http://foodbookingapi.somee.com/api/GetProductByID/" + productID);
            Product productConverted = JsonConvert.DeserializeObject<List<Product>>(product)[0];
            return await Task.FromResult(productConverted);
        }
    }
}
