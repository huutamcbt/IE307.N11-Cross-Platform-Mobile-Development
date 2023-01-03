using System;
using System.Collections.Generic;
using System.Text;

namespace Frontend.Models
{
    public class ShoppingSession
    {
        public int SessionId { get; set; }
        public int UserId { get; set; }
        public int Total { get; set; }
    }
}
