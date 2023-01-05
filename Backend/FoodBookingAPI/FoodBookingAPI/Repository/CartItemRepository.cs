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
    public class CartItemRepository
    {
        private static void AddParameters(SqlCommand command , Dictionary<string, object> param)
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
                            case nameof(CartItems.CartItemId):
                                command.Parameters.Add("@" + data.Key, SqlDbType.Int);
                                command.Parameters["@" + data.Key].Value = data.Value;
                                Debug.WriteLine("CartItemId" + command.Parameters["@" + data.Key].Value);
                                break;
                            case nameof(CartItems.SessionId):
                                command.Parameters.Add("@" + data.Key, SqlDbType.Int);
                                command.Parameters["@" + data.Key].Value = data.Value;
                                Debug.WriteLine("SessionId" + command.Parameters["@" + data.Key].Value);
                                break;
                            case nameof(CartItems.ProductId):
                                command.Parameters.Add("@" + data.Key, SqlDbType.Int);
                                command.Parameters["@" + data.Key].Value = data.Value;
                                Debug.WriteLine("ProductId" + command.Parameters["@" + data.Key].Value);
                                break;
                            case nameof(CartItems.Quantity):
                                command.Parameters.Add("@" + data.Key, SqlDbType.Int);
                                command.Parameters["@" + data.Key].Value = data.Value;
                                Debug.WriteLine("Quantity" + command.Parameters["@" + data.Key].Value);
                                break;
                            case nameof(CartItems.CreatedDate):
                                command.Parameters.Add("@" + data.Key, SqlDbType.DateTime);
                                command.Parameters["@" + data.Key].Value = data.Value;
                                Debug.WriteLine("CreatedDate" + command.Parameters["@" + data.Key].Value);
                                break;
                            case nameof(CartItems.ModifiedDate):
                                command.Parameters.Add("@" + data.Key, SqlDbType.DateTime);
                                command.Parameters["@" + data.Key].Value = data.Value;
                                Debug.WriteLine("ModifiedDate" + command.Parameters["@" + data.Key].Value);
                                break;
                        }
                    }
                }
            }
        }

        public static bool AddCartItem(Dictionary<string, object> param)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(Constant.SQLConnectionString))
                {
                    connection.Open();

                    string query = Constant.CartItem_Procedure_AddCartItem;
                    using(SqlCommand command = new SqlCommand(query, connection))
                    {
                        AddParameters(command, param);
                        Debug.WriteLine(param);
                        command.CommandType = CommandType.StoredProcedure;
                        Int32 cartItemId = Convert.ToInt32(command.ExecuteScalar());

                        if (cartItemId > 0)
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

        public static DataTable GetCartItemBySessionId(Dictionary<string, object> param)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(Constant.SQLConnectionString))
                {
                    connection.Open();

                    string query = Constant.CartItem_Procedure_GetCartItemBySessionId;
                    using(SqlCommand command = new SqlCommand(query, connection))
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
        public static bool UpdateCartItem(Dictionary<string, object> param)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(Constant.SQLConnectionString))
                {
                    connection.Open();

                    string query = Constant.CartItem_Procedure_UpdateCartItem;
                    using(SqlCommand command = new SqlCommand(query, connection))
                    {
                        AddParameters(command, param);

                        command.CommandType = CommandType.StoredProcedure;
                        object result = command.ExecuteScalar();

                        Int32 cartItemId = Convert.ToInt32(result);
                        Debug.WriteLine(cartItemId);

                        if (cartItemId > 0)
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

        public static bool DeleteCartItem(Dictionary<string, object> param)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(Constant.SQLConnectionString))
                {
                    connection.Open();

                    string query = Constant.CartItem_Procedure_DeleteCartItem;
                    using(SqlCommand command = new SqlCommand(query, connection))
                    {
                        AddParameters(command, param);

                        command.CommandType = CommandType.StoredProcedure;
                        int cartItemId = (int)command.ExecuteScalar();

                        if (cartItemId > 0)
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