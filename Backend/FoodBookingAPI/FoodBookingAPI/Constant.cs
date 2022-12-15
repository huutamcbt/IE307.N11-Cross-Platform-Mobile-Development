using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodBookingAPI
{
    public class Constant
    {
        public static string Product_Procedure_GetAll => "usp_GetAllProduct";
        public static string Product_Procedure_GetProduct_By_Id => "usp_GetProductById";
        public static string Product_Procedure_GetProduct_By_CategoryId => "usp_GetProductByCategory";
        public static string ProductCategory_Procedure_GetAll => "usp_GetAllCategory";
    }
}