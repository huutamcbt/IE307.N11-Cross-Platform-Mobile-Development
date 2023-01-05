using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodBookingAPI.Models
{
    public class OrderDetails
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public double Total { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}