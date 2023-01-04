namespace Frontend.Models
{
    public class OrderDetail
    {
        public int OrderId { get; set; }
        public int PaymentId { get; set; }
        public int UserId { get; set; }
        public float Total { get; set; }

    }
}
