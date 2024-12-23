namespace ShoppingAPI.Models.DTO
{
    public class SupplierProductDTO
    {
        public string SupplierId { get; set; } = string.Empty;
        public string SupplierName { get; set; } = string.Empty;
        public List<Product>? Products { get; set; }

    }
}
