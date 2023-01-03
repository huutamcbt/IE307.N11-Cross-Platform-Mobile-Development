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
    public class ProductCategoryRepository
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
                            case nameof(ProductCategorys.CategoryId):
                                command.Parameters.Add("@" + data.Key, SqlDbType.Int);
                                command.Parameters["@" + data.Key].Value = data.Value;
                                break;
                            case nameof(ProductCategorys.Name):
                                command.Parameters.Add("@" + data.Key, SqlDbType.NVarChar, 30);
                                command.Parameters["@" + data.Key].Value = data.Value;
                                break;
                            case nameof(ProductCategorys.Description):
                                command.Parameters.Add("@" + data.Key, SqlDbType.NVarChar, 100);
                                command.Parameters["@" + data.Key].Value = data.Value;
                                break;
                            case nameof(ProductCategorys.Image):
                                command.Parameters.Add("@" + data.Key, SqlDbType.VarChar, 100);
                                command.Parameters["@" + data.Key].Value = data.Value;
                                break;
                            case nameof(ProductCategorys.CreatedDate):
                                command.Parameters.Add("@" + data.Key, SqlDbType.DateTime);
                                command.Parameters["@" + data.Key].Value = data.Value;
                                break;
                            case nameof(ProductCategorys.ModifiedDate):
                                command.Parameters.Add("@" + data.Key, SqlDbType.DateTime);
                                command.Parameters["@" + data.Key].Value = data.Value;
                                break;
                            case nameof(ProductCategorys.DeletedDate):
                                command.Parameters.Add("@" + data.Key, SqlDbType.DateTime);
                                command.Parameters["@" + data.Key].Value = data.Value;
                                break;
                        }

                    }
                }
            }
        }
        public static DataTable GetAllCategory()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Constant.SQLConnectionString))
                {
                    connection.Open();

                    string query = Constant.ProductCategory_Procedure_GetAll;
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
                Debug.WriteLine("Error while get all categorys");
                return null;
            }
        }
      
    }
}