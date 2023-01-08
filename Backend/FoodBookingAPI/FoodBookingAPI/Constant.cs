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
        public const string Product_Procedure_GetAll = "usp_GetAllProduct";
        public const string Product_Procedure_GetProduct_By_Id = "usp_GetProductById";
        public const string Product_Procedure_GetProduct_By_CategoryId = "usp_GetProductByCategory";
        public const string Product_Procedure_UpdateProduct_By_Id = "usp_UpdateProductById";

        // Product Category
        public const string ProductCategory_Procedure_GetAll = "usp_GetAllCategory";

        // User Address
        public const string UserAddress_Procedure_AddUserAddress = "usp_AddUserAddress";
        public const string UserAddress_Procedure_UpdateUserAddress = "usp_UpdateUserAddress";
        public const string UserAddress_Procedure_RemoveUserAddress = "usp_RemoveAddress";

        // User
        public const string User_Procedure_GetUserById = "usp_GetUSerById";
        public const string User_Procedure_AddUser = "usp_AddUser";
        public const string User_Procedure_UpdateUser = "usp_UpdateUser";

        // Review
        public const string Review_Procedure_GetReviewByProductId = "usp_GetReviewsByProductId";
        public const string Review_Procedure_AddReview = "usp_AddReview";
        public const string Review_Procedure_UpdateReview = "usp_UpdateReview";
        public const string Review_Procedure_DeleteReview = "usp_DeleteReview";

        // CartItem
        public const string CartItem_Procedure_AddCartItem = "usp_AddCartItem";
        public const string CartItem_Procedure_GetCartItemBySessionId = "usp_GetCartItemBySessionId";
        public const string CartItem_Procedure_UpdateCartItem = "usp_UpdateCartItem";
        public const string CartItem_Procedure_DeleteCartItem = "usp_DeleteCartItem";

        // SQL Connection
        public static string SQLConnectionString => ConfigurationManager.ConnectionStrings["FoodBooking"].ConnectionString;
    }
}