using System;
using System.Collections.Generic;
using System.Text;

namespace Frontend.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public int SessionId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
