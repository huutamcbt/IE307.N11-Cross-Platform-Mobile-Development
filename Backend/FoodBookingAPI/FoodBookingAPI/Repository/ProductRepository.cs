using FoodBookingAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FoodBookingAPI.Repository
{
    public class ProductRepository
    {
        public static DataTable GetAllProduct()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Constant.SQLConnectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM " + nameof(Products);
                    using(SqlCommand command = new SqlCommand(query, connection))
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
        public static DataTable GetProductById()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Constant.SQLConnectionString))
                {
                    connection.Open();

                    string query = $"SELECT * " +
                        $"FROM {nameof(Products.ProductId)}" +
                        $"WHERE @{nameof(Products.ProductId)} = {nameof(Products.ProductId)}";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
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