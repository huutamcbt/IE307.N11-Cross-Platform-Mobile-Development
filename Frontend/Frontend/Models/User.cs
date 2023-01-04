using System;
using System.Collections.Generic;
using System.Text;

namespace Frontend.Models
{
    public class User
    {
        public int UserId { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String Firstname { get; set; }
        public String Lastname { get; set; }
        public String Telephone { get; set; }
        public String Logo { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
