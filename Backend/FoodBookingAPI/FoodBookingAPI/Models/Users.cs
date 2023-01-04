using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodBookingAPI.Models
{
    public class Users
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Logo { get; set; }
    }
}