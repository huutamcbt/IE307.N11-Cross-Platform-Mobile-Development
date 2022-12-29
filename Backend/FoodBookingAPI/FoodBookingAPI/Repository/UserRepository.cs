using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using FoodBookingAPI.Models;

namespace FoodBookingAPI.Repository
{
    public class UserRepository
    {
        private static void AddParameters(Dictionary<string, object> param, SqlCommand command)
        {
            if(param!= null)
            {
                foreach(KeyValuePair<string, object> data in param)
                {
                    if(data.Value == null)
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
                                command.Parameters.Add("@" + data.Key, SqlDbType.VarChar,20);
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
        
    }
}