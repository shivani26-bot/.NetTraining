namespace OrderMicroserviceAPI.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; } = "Pending";
        public string Username { get; set; } = "Anonymous";
        public ICollection<OrderDetails> OrderItems { get; set; }
        public Order()
        {
            OrderItems = new List<OrderDetails>();
        }
    }
}
