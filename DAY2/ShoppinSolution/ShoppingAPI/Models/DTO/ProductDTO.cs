namespace ShoppingAPI.Models.DTO
{
    public class ProductDTO
    {
        public  int Id { get; set; } //product id
        public string Title { get; set; }= string.Empty;
        public float PricePerUnit { get; set; }
        public string Description { get; set; }= string.Empty;
        public int StockAvailable { get; set; }
        public string Status { get; set; } = string.Empty;
        public  int CategoryId { get; set; }
    }
}
