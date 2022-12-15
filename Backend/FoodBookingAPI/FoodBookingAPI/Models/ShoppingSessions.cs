using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodBookingAPI.Models
{
    public class ShoppingSessions
    {
        public int SessionId { get; set; }
        public int UserId { get; set; }
        public double Total { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}