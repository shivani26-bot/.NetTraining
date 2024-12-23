namespace SagaOrchestratorAPI.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; } = "Pending";
        public string Username { get; set; } = "Anonymous";
    }
}
