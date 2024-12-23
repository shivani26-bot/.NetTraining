namespace OrderMicroserviceAPI.Models
{
    public class OrderDetails
    {
        public int OrderId { get; set; }
        public int Id { get; set; }
        public int ProdcutId { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public Order Order { get; set; }
        public OrderDetails()
        {
            Order = new Order();
        }
    
}
}
