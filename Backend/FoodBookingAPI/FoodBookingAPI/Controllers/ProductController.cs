using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;


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
                DataTable dt = ProductRepository.ReadData(Constant.Product_Procedure_GetAll);
                
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
                param.Add("ProductId", id);

                DataTable data = ProductRepository.ReadData(Constant.Product_Procedure_GetProduct_By_Id, param);

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
                param.Add("CategoryId", id);
                DataTable data = ProductRepository.ReadData(Constant.Product_Procedure_GetProduct_By_CategoryId, param);

                return Ok(data);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}