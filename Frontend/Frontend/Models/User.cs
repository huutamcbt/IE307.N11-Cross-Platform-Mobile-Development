using System;

namespace Frontend.Models
{
    public class User
    {
        public int UserId { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Telephone { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public String Logo { get; set; }
    }
}
