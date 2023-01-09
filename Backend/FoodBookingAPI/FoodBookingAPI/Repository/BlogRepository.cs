using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

using FoodBookingAPI.Models;

namespace FoodBookingAPI.Repository
{
    public class BlogRepository
    {
        private static void AddParameters(SqlCommand command, Dictionary<string, object> param)
        {
            if(param != null)
            {
                foreach (KeyValuePair<string, object> data in param)
                {
                    if(data.Value == null)
                    {
                        command.Parameters.AddWithValue("@" + data.Key, DBNull.Value);
                    }
                    else
                    {
                        switch (data.Key)
                        {
                            case nameof(Blogs.BlogId):
                                command.Parameters.Add("@" + data.Key, SqlDbType.Int);
                                command.Parameters["@" + data.Key].Value = data.Value;
                                break;
                            case nameof(Blogs.Title):
                                command.Parameters.Add("@" + data.Key, SqlDbType.NVarChar, 30);
                                command.Parameters["@" + data.Key].Value = data.Value;
                                break;
                            case nameof(Blogs.Content):
                                command.Parameters.Add("@" + data.Key, SqlDbType.NVarChar,900);
                                command.Parameters["@" + data.Key].Value = data.Value;
                                break;
                            case nameof(Blogs.CreatedDate):
                                command.Parameters.Add("@" + data.Key, SqlDbType.DateTime);
                                command.Parameters["@" + data.Key].Value = data.Value;
                                break;
                            case nameof(Blogs.ModifiedDate):
                                command.Parameters.Add("@" + data.Key, SqlDbType.DateTime);
                                command.Parameters["@" + data.Key].Value = data.Value;
                                break;
                            case nameof(Blogs.DeletedDate):
                                command.Parameters.Add("@" + data.Key, SqlDbType.DateTime);
                                command.Parameters["@" + data.Key].Value = data.Value;
                                break;
                        }
                    }
                }
            }
        }

        public static DataTable GetAllBlogs()
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(Constant.SQLConnectionString))
                {
                    connection.Open();

                    string query = Constant.Blog_Procedure_GetAllBlogs;
                    using(SqlCommand command = new SqlCommand(query, connection))
                    {
                    
                        command.CommandType = CommandType.StoredProcedure;

                        using(SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable result = new DataTable();
                            adapter.Fill(result);

                            if (result.Rows.Count > 0)
                                return result;
                            return null;
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