using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using FoodBookingAPI.Models;

namespace FoodBookingAPI.Repository
{
    public class ProductRepository
    {
        public static DataTable ReadData(string procedureName, Dictionary<string, object> param = null)
        {
            try
            {
                // sql connection string
                string connectionString = ConfigurationManager.ConnectionStrings["FoodBooking"].ConnectionString;
                
                // Procedure name
                string query = procedureName;
                
                // Init sql connection to sql server
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Create command for sql
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameter for sql command
                        if (param != null)
                        {
                            foreach(KeyValuePair<string,object> data in param)
                            {
                                if(data.Value == null)
                                {
                                    command.Parameters.AddWithValue("@" + data.Key, DBNull.Value);
                                }
                                else
                                {
                                    command.Parameters.AddWithValue("@" + data.Key, data.Value);
                                }
                            }
                        }
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
                throw;
            }
        }
    }
}