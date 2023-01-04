using System;

namespace Frontend.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public int SessionId { get; set; }
        public int ProuductId { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
