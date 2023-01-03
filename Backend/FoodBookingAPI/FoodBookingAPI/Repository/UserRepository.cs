using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using FoodBookingAPI.Models;
using System.Diagnostics;

namespace FoodBookingAPI.Repository
{
    public class UserRepository
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
                            case nameof(Users.UserId):
                                command.Parameters.Add("@" + data.Key, SqlDbType.Int);
                                command.Parameters["@" + data.Key].Value = data.Value;
                                break;
                            case nameof(Users.Username):
                                command.Parameters.Add("@" + data.Key, SqlDbType.VarChar, 20);
                                command.Parameters["@" + data.Key].Value = data.Value;
                                break;
                            case nameof(Users.Password):
                                command.Parameters.Add("@" + data.Key, SqlDbType.Text);
                                command.Parameters["@" + data.Key].Value = data.Value;
                                break;
                            case nameof(Users.FirstName):
                                command.Parameters.Add("@" + data.Key, SqlDbType.NVarChar, 50);
                                command.Parameters["@" + data.Key].Value = data.Value;
                                break;
                            case nameof(Users.LastName):
                                command.Parameters.Add("@" + data.Key, SqlDbType.NVarChar, 20);
                                command.Parameters["@" + data.Key].Value = data.Value;
                                break;
                            case nameof(Users.Telephone):
                                command.Parameters.Add("@" + data.Key, SqlDbType.VarChar, 15);
                                command.Parameters["@" + data.Key].Value = data.Value;
                                break;
                            case nameof(Users.CreatedDate):
                                command.Parameters.Add("@" + data.Key, SqlDbType.DateTime);
                                command.Parameters["@" + data.Key].Value = data.Value;
                                break;
                            case nameof(Users.ModifiedDate):
                                command.Parameters.Add("@" + data.Key, SqlDbType.DateTime);
                                command.Parameters["@" + data.Key].Value = data.Value;
                                break;
                            case nameof(Users.Logo):
                                command.Parameters.Add("@" + data.Key, SqlDbType.VarChar, 100);
                                command.Parameters["@" + data.Key].Value = data.Value;
                                break;
                        }
                    }
                }
            }
        }

        public static DataTable GetUserById(Dictionary<string, object> param)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Constant.SQLConnectionString))
                {
                    connection.Open();
                    Debug.WriteLine("Get User By Id");
                    string query = Constant.User_Procedure_GetUserById;
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        AddParameters(command, param);

                        using(SqlDataAdapter adapter = new SqlDataAdapter(command))
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
                return null;
            }
        }

        public static bool UpdateUser(Dictionary<string, object> param)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(Constant.SQLConnectionString))
                {
                    connection.Open();

                    string query = Constant.User_Procedure_UpdateUser;
                    using(SqlCommand command = new SqlCommand(query, connection))
                    {
                        AddParameters(command, param);

                        command.CommandType = CommandType.StoredProcedure;
                        int userId = (int)command.ExecuteScalar();

                        if (userId > 0)
                            return true;
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}