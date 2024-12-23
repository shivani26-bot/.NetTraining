namespace ProductMicroservice.Models.DTOs
{
    public class UpdateProductRequestDTO
    {
        public ProductPriceUpdateRequestDTO? PriceUpdate { get; set; }
        public ProductStockUpdateRequestDTO? StockUpdate { get; set; }
    }
}
