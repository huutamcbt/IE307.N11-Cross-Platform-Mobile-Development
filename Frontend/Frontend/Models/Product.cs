using System;
using System.Collections.Generic;
using System.Text;

namespace Frontend.Models
{
    public class Product
    {
        public Product(int iD, string name, double price, string image, int categoryID, int stock, int quantity , string description)
        {
            ProductId = iD;
            Name = name;
            Price = price;
            Image = image;
            CategoryID = categoryID;
            Stock = stock;
            Quantity = quantity;
            Description = description;
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public int CategoryID { get; set; }
        public int Stock { get; set; }
        public int Quantity { get; set; } // Chi frontend co
        public string Description { get; set; }

        

    }
}
