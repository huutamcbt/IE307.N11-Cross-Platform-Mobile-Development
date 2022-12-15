using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodBookingAPI.Models
{
    public class Reviews
    {
        public int ReviewId { get; set; }
        public int ProductId { get; set; }
        public int Rating { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime DeletedDate { get; set; }
    }
}