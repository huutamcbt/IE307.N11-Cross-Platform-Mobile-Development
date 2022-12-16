using System;
using System.Collections.Generic;
using System.Text;
using Frontend.Models;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace Frontend.Services
{
    class ProductService
    {
        public ProductService()
        {
            //products = new List<Product>
            //{
            //    new Product(1, "Bún Bò Huế", 35000, "https://firebasestorage.googleapis.com/v0/b/elegant-skein-350903.appspot.com/o/Food%2FBun_bo_hue.jpg?alt=media&token=f8f49341-0907-48a5-913f-0e9248535cf2", 1 , 9999, 1, "abxcvdfgcd"),
            //    new Product(2, "Bún Bò Huế", 35000, "https://firebasestorage.googleapis.com/v0/b/elegant-skein-350903.appspot.com/o/Food%2FBun_bo_hue.jpg?alt=media&token=f8f49341-0907-48a5-913f-0e9248535cf2", 1 , 9999, 1, "abcd"),
            //    new Product(3, "Bún Bò Huế", 35000, "https://firebasestorage.googleapis.com/v0/b/elegant-skein-350903.appspot.com/o/Food%2FBun_bo_hue.jpg?alt=media&token=f8f49341-0907-48a5-913f-0e9248535cf2", 1 , 9999, 1, "abcd")
            //};
        }
        //public async Task<bool> AddItemAsync(Product product)
        //{
        //    products.Add(product);

        //    return await Task.FromResult(true);
        //}

        //public async Task<bool> RemoveItemAsync(Product product)
        //{

        //    products.Remove(product);

        //    return await Task.FromResult(true);
        //}
        //public async Task<List<Product>> GetProductsByCategoryID(Category category)
        //{
        //    return await Task.FromResult(products.FindAll((Product product) => product.CategoryID == category.ID));
        //}
        //public async Task<Product> GetProductByID(int productID)
        //{
        //    return await Task.FromResult(products.Find((Product product) => product.ID == productID));
        //}

        public async Task<List<Product>> GetAllProduct()
        {
            HttpClient httpClient = new HttpClient();
            var productList = await httpClient.GetStringAsync("http://172.17.26.241/FoodBookingAPI/api/GetAllProduct");
            List<Product> productListConverted = JsonConvert.DeserializeObject<List<Product>>(productList);
            return await Task.FromResult(productListConverted);
        }

    }
}
