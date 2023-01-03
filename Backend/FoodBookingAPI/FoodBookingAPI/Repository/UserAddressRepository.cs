using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using FoodBookingAPI.Models;

namespace FoodBookingAPI.Repository
{
    public class UserAddressRepository
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
                            case nameof(UserAddresss.AddressId):
                                command.Parameters.Add("@" + data.Key, SqlDbType.Int);
                                command.Parameters["@" + data.Key].Value = data.Value;
                                break;
                            case nameof(UserAddresss.UserId):
                                command.Parameters.Add("@" + data.Key, SqlDbType.Int);
                                command.Parameters["@" + data.Key].Value = data.Value;
                                break;
                            case nameof(UserAddresss.Address):
                                command.Parameters.Add("@" + data.Key, SqlDbType.NVarChar, 50);
                                command.Parameters["@" + data.Key].Value = data.Value;
                                break;
                            case nameof(UserAddresss.District):
                                command.Parameters.Add("@" + data.Key, SqlDbType.NVarChar, 50);
                                command.Parameters["@" + data.Key].Value = data.Value;
                                break;
                            case nameof(UserAddresss.Province):
                                command.Parameters.Add("@" + data.Key, SqlDbType.NVarChar, 15);
                                command.Parameters["@" + data.Key].Value = data.Value;
                                break;
                            case nameof(UserAddresss.City):
                                command.Parameters.Add("@" + data.Key, SqlDbType.NVarChar, 30);
                                command.Parameters["@" + data.Key].Value = data.Value;
                                break;
                            case nameof(UserAddresss.Country):
                                command.Parameters.Add("@" + data.Key, SqlDbType.NVarChar, 15);
                                command.Parameters["@" + data.Key].Value = data.Value;
                                break;
                            case nameof(UserAddresss.Mobile):
                                command.Parameters.Add("@" + data.Key, SqlDbType.VarChar, 15);
                                command.Parameters["@" + data.Key].Value = data.Value;
                                break;
                        }
                    }
                }
            }
        }

        public static DataTable GetAddressesByUserId(Dictionary<string, object> param)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Constant.SQLConnectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM " + nameof(UserAddresss) + " "
                        + "WHERE UserId = @UserId;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        AddParameters(command, param);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable result = new DataTable();
                            command.CommandType = CommandType.Text;
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

        public static bool AddAddress(Dictionary<string, object> param)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Constant.SQLConnectionString))
                {
                    connection.Open();

                    string query = Constant.UserAddress_Procedure_AddUserAddress;
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        AddParameters(command, param);

                        command.CommandType = CommandType.StoredProcedure;
                        int check = (int)command.ExecuteScalar();

                        if (check > 0)
                            return true;
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to add new user address");
                return false;
            }
        }

        public static bool UpdateAddress(Dictionary<string, object> param)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Constant.SQLConnectionString))
                {
                    connection.Open();

                    //string query = "UPDATE " + nameof(UserAddresss) + " "
                    //                + "SET UserId = @UserId, Address = @Address, District = @District, Province = @Province, City = @City, Country = @Country, Mobile = @Mobile "
                    //                + "OUTPUT Inserted.AddressId "
                    //                + "WHERE AddressId = @AddressId";
                    string query = Constant.UserAddress_Procedure_UpdateUserAddress;

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters 
                        AddParameters(command, param);

                        command.CommandType = CommandType.StoredProcedure;
                        Int32 row = (Int32)command.ExecuteScalar();
                        Console.WriteLine(row);
                        if (row > 0)
                            return true;
                        else return false;
                    }
                }
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to update user address");
                return false;
            }
        }

        public static bool DeleteAddress(Dictionary<string, object> param)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(Constant.SQLConnectionString))
                {
                    connection.Open();

                    string query = Constant.UserAddress_Procedure_RemoveUserAddress;
                    using(SqlCommand command = new SqlCommand(query, connection))
                    {
                        AddParameters(command, param);

                        command.CommandType = CommandType.StoredProcedure;
                        int row = (int)command.ExecuteScalar();

                        if (row > 0)
                            return true;
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to remove user address");
                return false;
            }
        }
    }
}