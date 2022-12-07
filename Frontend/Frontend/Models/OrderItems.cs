using System;
using System.Collections.Generic;
using System.Text;

namespace Frontend.Models
{
    public class OrderItems
    {
        private int ID { get; set; }
        private int OrderID { get; set; }
        private int ProductID { get; set; }
        private int Quantity { get; set; }

    }
}
