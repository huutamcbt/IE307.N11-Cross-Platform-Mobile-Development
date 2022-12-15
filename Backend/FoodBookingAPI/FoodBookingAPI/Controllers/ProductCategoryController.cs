using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;
using FoodBookingAPI.Repository;

namespace FoodBookingAPI.Controllers
{
    public class ProductCategoryController : ApiController
    {
        Dictionary<string, object> param = new Dictionary<string, object>();
        [Route("api/GetAllCategory")]
        [HttpGet]
        public IHttpActionResult GetAllCategory()
        {
            try
            {
                DataTable data = ProductRepository.ReadData(Constant.ProductCategory_Procedure_GetAll);

                return Ok(data);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}