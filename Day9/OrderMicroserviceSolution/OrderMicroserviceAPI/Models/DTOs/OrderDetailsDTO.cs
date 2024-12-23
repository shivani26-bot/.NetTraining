namespace OrderMicroserviceAPI.Models.DTOs
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public float Price { get; set; }
        public int Quantity { get; set; }
    }
    public class OrderDetailsDTO
    {
        public int OrderId { get; set; }
        public List<ProductDTO> Products { get; set; } = new List<ProductDTO>();
        public string OrderStatus { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public string Username { get; set; }

    }
    
}
