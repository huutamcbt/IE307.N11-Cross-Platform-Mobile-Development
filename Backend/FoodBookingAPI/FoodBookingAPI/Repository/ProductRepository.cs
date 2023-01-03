using FoodBookingAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace FoodBookingAPI.Repository
{
    public class ProductRepository
    {
        private static void AddParameters(SqlCommand command, Dictionary<string, object> param)
        {
            
            if (param != null)
            {
                foreach (KeyValuePair<string, object> data in param)
                {
                    if (data.Value == null)
                    {
                        command.Parameters.AddWithValue("@" + data.Key, DBNull.Value);
                    }
                    else
                    {
                        switch (data.Key)
                        {
                            case nameof(Products.ProductId):
                                command.Parameters.Add("@" + data.Key, SqlDbType.Int);
                                command.Parameters["@" + data.Key].Value = data.Value;
                                break;
                            case nameof(Products.Name):
                                command.Parameters.Add("@" + data.Key, SqlDbType.NVarChar, 30);
                                command.Parameters["@" + data.Key].Value = data.Value;
                                break;
                            case nameof(Products.Description):
                                command.Parameters.Add("@" + data.Key, SqlDbType.NVarChar, 200);
                                command.Parameters["@" + data.Key].Value = data.Value;
                                break;
                            case nameof(Products.CategoryId):
                                command.Parameters.Add("@" + data.Key, SqlDbType.Int);
                                command.Parameters["@" + data.Key].Value = data.Value;
                                break;
                            case nameof(Products.Price):
                                command.Parameters.Add("@" + data.Key, SqlDbType.Float);
                                command.Parameters["@" + data.Key].Value = data.Value;
                                break;
                            case nameof(Products.DiscountId):
                                command.Parameters.Add("@" + data.Key, SqlDbType.Int);
                                command.Parameters["@" + data.Key].Value = data.Value;
                                break;
                            case nameof(Products.CreatedDate):
                                command.Parameters.Add("@" + data.Key, SqlDbType.DateTime);
                                command.Parameters["@" + data.Key].Value = data.Value;
                                break;
                            case nameof(Products.ModifiedDate):
                                command.Parameters.Add("@" + data.Key, SqlDbType.DateTime);
                                command.Parameters["@" + data.Key].Value = data.Value;
                                break;
                            case nameof(Products.DeletedDate):
                                command.Parameters.Add("@" + data.Key, SqlDbType.DateTime);
                                command.Parameters["@" + data.Key].Value = data.Value;
                                break;
                            case nameof(Products.Stock):
                                command.Parameters.Add("@" + data.Key, SqlDbType.Int);
                                command.Parameters["@" + data.Key].Value = data.Value;
                                break;
                            case nameof(Products.Image):
                                command.Parameters.Add("@" + data.Key, SqlDbType.VarChar, 200);
                                command.Parameters["@" + data.Key].Value = data.Value;
                                break;
                        }

                    }
                }
            }
        }
        public static DataTable GetAllProduct()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Constant.SQLConnectionString))
                {
                    connection.Open();

                    string query = Constant.Product_Procedure_GetAll;
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
                Debug.WriteLine("Error while get all products");
                return null;
            }
        }
        public static DataTable GetProductById(Dictionary<string, object> param)
        {
            try
            {
                // Init sql connection to sql server
                using (SqlConnection connection = new SqlConnection(Constant.SQLConnectionString))
                {
                    connection.Open();
                    // Create command for sql
                    string query = Constant.Product_Procedure_GetProduct_By_Id;
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameter for sql command
                        AddParameters(command, param);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable result = new DataTable();
                            command.CommandType = CommandType.StoredProcedure;
                            adapter.Fill(result);
                            
                            return result;
                        }
                    }
                }
            }
            catch (Exception)
            {
                Debug.WriteLine("Error while get product");
                return null;
            }
        }
        public static DataTable GetProductByCategoryId(Dictionary<string, object> param)
        {
            try
            {
                // Init sql connection to sql server
                using (SqlConnection connection = new SqlConnection(Constant.SQLConnectionString))
                {
                    connection.Open();
                    // Create command for sql
                    string query = Constant.Product_Procedure_GetProduct_By_CategoryId;
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameter for sql command
                        AddParameters(command, param);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable result = new DataTable();
                            command.CommandType = CommandType.StoredProcedure;
                            adapter.Fill(result);

                            return result;
                        }
                    }
                }
            }
            catch (Exception)
            {
                Debug.WriteLine("Error while get product");
                return null;
            }
        }
    }
}