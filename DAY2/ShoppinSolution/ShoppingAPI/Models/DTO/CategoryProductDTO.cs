namespace ShoppingAPI.Models.DTO
{
    public class CategoryProductDTO
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public List<Product>?  Products { get; set; }
    }
}
