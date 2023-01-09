using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

using FoodBookingAPI.Models;

namespace FoodBookingAPI.Repository
{
    public class OrderDetailRepository
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
                            case nameof(OrderDetails.OrderId):
                                command.Parameters.Add("@" + data.Key, SqlDbType.Int);
                                command.Parameters["@" + data.Key].Value = data.Value;
                                break;
                            case nameof(OrderDetails.UserId):
                                command.Parameters.Add("@" + data.Key, SqlDbType.Int);
                                command.Parameters["@" + data.Key].Value = data.Value;
                                break;
                            case nameof(OrderDetails.Total):
                                command.Parameters.Add("@" + data.Key, SqlDbType.Float);
                                command.Parameters["@" + data.Key].Value = data.Value;
                                break;
                            case nameof(OrderDetails.CreatedDate):
                                command.Parameters.Add("@" + data.Key, SqlDbType.DateTime);
                                command.Parameters["@" + data.Key].Value = data.Value;
                                break;
                            case nameof(OrderDetails.ModifiedDate):
                                command.Parameters.Add("@" + data.Key, SqlDbType.DateTime);
                                command.Parameters["@" + data.Key].Value = data.Value;
                                break;
                        }
                    }
                }
            }
        }

        public static DataTable GetOrderDetailByUserId(Dictionary<string, object> param)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(Constant.SQLConnectionString))
                {
                    connection.Open();

                    string query = Constant.OrderDetail_Procedure_GetOrderDetailByUserId;
                    using(SqlCommand command = new SqlCommand(query, connection))
                    {
                        AddParameters(command, param);
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

        public static int AddOrderDetail(Dictionary<string, object> param)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Constant.SQLConnectionString))
                {
                    connection.Open();

                    string query = Constant.OrderDetail_Procedure_AddOrderDetail;
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        AddParameters(command, param);

                        command.CommandType = CommandType.StoredProcedure;
                        int OrderId = (int)command.ExecuteScalar();

                        return OrderId;
                    }
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}