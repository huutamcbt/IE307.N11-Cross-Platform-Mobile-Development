using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;
using FoodBookingAPI.Models;
using FoodBookingAPI.Repository;

namespace FoodBookingAPI.Controllers
{
    public class ProductController : ApiController
    {
        Dictionary<string, object> param = new Dictionary<string, object>();
        // Get all products
        [Route("api/GetAllProduct")]
        [HttpGet]
        public IHttpActionResult GetAllProducts()
        {
            try
            {
                DataTable dt = ProductRepository.GetAllProduct();
                
                return Ok(dt);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [Route("api/GetProductById/{id}")]
        [HttpGet]
        public IHttpActionResult GetProductById(int id)
        {
            try
            {
                // Add Product Id parameter
                param.Add(nameof(Products.ProductId), id);

                DataTable data = GeneralRepository.ReadData(Constant.Product_Procedure_GetProduct_By_Id, param);

                return Ok(data);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [Route("api/GetProductByCategory/{id}")]
        [HttpGet]
        public IHttpActionResult GetProductByCategoryId(int id)
        {
            try
            {
                param.Add(nameof(Products.CategoryId), id);
                DataTable data = GeneralRepository.ReadData(Constant.Product_Procedure_GetProduct_By_CategoryId, param);

                return Ok(data);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [Route("api/UpdateProductById/{id}")]
        [HttpPost]
        public IHttpActionResult UpdateProductById(int id, string productName, string desc)
        {
            try
            {
                Debug.WriteLine("Product Name: " + productName);
                param.Add(nameof(Products.ProductId), id);
                param.Add(nameof(Products.Name), productName);
                param.Add(nameof(Products.Description), desc);

                DataTable data = GeneralRepository.ReadData(Constant.Product_Procedure_UpdateProduct_By_Id, param);

                return Ok(data);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}