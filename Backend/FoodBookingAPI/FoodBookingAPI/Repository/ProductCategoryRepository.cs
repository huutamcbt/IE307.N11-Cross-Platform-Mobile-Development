using FoodBookingAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FoodBookingAPI.Repository
{
    public class ProductCategoryRepository
    {
        public static DataTable GetAllCategory()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Constant.SQLConnectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM " + nameof(ProductCategorys);
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using(SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable result = new DataTable();
                            adapter.Fill(result);

                            return result;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
      
    }
}