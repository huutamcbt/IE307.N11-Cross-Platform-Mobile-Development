using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodBookingAPI.Models
{
    public class UserPayments
    {
        public int UserPaymentId { get; set; }
        public int UserId { get; set; }
        public string PaymentType { get; set; }
        public string Provider { get; set; }
        public string AccountNo { get; set; }
        public DateTime Expiry { get; set; }
    }
}