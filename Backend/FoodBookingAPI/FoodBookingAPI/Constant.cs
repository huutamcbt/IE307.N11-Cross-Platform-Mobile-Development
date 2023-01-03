using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace FoodBookingAPI
{
    public class Constant
    {
        //Product
        public static string Product_Procedure_GetAll => "usp_GetAllProduct";
        public static string Product_Procedure_GetProduct_By_Id => "usp_GetProductById";
        public static string Product_Procedure_GetProduct_By_CategoryId => "usp_GetProductByCategory";
        public static string Product_Procedure_UpdateProduct_By_Id => "usp_UpdateProductById";

        // Product Category
        public static string ProductCategory_Procedure_GetAll => "usp_GetAllCategory";

        // User Address
        public static string UserAddress_Procedure_AddUserAddress => "usp_AddUserAddress";
        public static string UserAddress_Procedure_UpdateUserAddress => "usp_UpdateUserAddress";
        public static string UserAddress_Procedure_RemoveUserAddress => "usp_RemoveAddress";

        // User
        public static string User_Procedure_GetUserById => "usp_GetUSerById";
        public static string User_Procedure_UpdateUser => "usp_UpdateUser";

        // Review
        public static string Review_Procedure_GetReviewByProductId => "usp_GetReviewsByProductId";
        public static string Review_Procedure_AddReview => "usp_AddReview";
        public static string Review_Procedure_UpdateReview => "usp_UpdateReview";
        public static string Review_Procedure_DeleteReview => "usp_DeleteReview";

        // SQL Connection
        public static string SQLConnectionString => ConfigurationManager.ConnectionStrings["FoodBooking"].ConnectionString;
    }
}