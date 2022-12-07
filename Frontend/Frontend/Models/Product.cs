using System;
using System.Collections.Generic;
using System.Text;

namespace Frontend.Models
{
    public class Product
    {
        private int ID { get; set; }
        private string Name { get; set; }
        private double Price { get; set; }
        private string Image { get; set; }
        private int CategoryID { get; set; }
        private int Stock { get; set; }
        private int Quantity { get; set; } // Chi frontend co
        private string Description { get; set; }



    }
}
