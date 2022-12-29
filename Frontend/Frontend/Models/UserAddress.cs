using System;
using System.Collections.Generic;
using System.Text;

namespace Frontend.Models
{
    public class UserAddress
    {
        public int AddressId { get; set; }
        public int UserId { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Mobile { get; set; }
    }
}
