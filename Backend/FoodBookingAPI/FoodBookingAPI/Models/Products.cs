using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodBookingAPI.Models
{
    public class Products
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public double Price { get; set; }
        public int DiscountId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime DeletedDate { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; }
    }
}