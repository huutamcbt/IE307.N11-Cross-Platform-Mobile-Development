using System;
using System.Collections.Generic;
using System.Text;

namespace Frontend.Models
{
    public class PaymentDetail
    {
        public int PaymentId { get; set; }
        public int OrderId { get; set; }
        public double Amount { get; set; }
        public string Provider { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
