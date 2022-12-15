using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodBookingAPI.Models
{
    public class PaymentDetails
    {
        public int PaymentId { get; set; }
        public int OrderId { get; set; }
        public double Amount { get; set; }
        public string Provider { get; set; }
        public string status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}