using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodBookingAPI
{
    public class CheckedCode
    {
        // User has already existed
        public static int EXISTED_USER => 5;
        // Error occurs when username is wrong
        public static int WRONG_USERNAME => 6;
        // Error occurs when password is wrong
        public static int WRONG_PASSWORD => 9;
        // Error occurs when id is wrong
        public static int WRONG_ID => 15;
        // All unknow errors
        public static int UNKNOW_ERROR => 20;
        // Error occurs when account is invalid 
        public static int INVALID_ACCOUNT => 21;
    }
}