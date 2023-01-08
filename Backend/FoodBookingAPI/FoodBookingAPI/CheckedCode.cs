using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodBookingAPI
{
    public class CheckedCode
    {
        // User has already existed
        public const int EXISTED_USER = 5;
        // Error occurs when username is wrong
        public const int WRONG_USERNAME = 21;
        // Error occurs when password is wrong
        public const int WRONG_PASSWORD = 22;
        // Error occurs when id is wrong
        public const int WRONG_ID = 23;
        // All unknow errors
        public const int UNKNOW_ERROR = 20;
        // Error occurs when account is invalid 
        public const int INVALID_ACCOUNT = 24;
        // Error occurs when updated password has already existed
        public const int EXISTED_PASSWORD = 6;
        // Successful value
        public const int OK = 200;
    }
}