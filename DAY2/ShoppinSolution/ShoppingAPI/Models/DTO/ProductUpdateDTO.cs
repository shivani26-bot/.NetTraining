namespace ShoppingAPI.Models.DTO
{
    public class ProductUpdateDTO
    {
        public ProductPriceUpdateRequestDTO? PriceChange { get; set; }
        public ProductStockUpdateRequestDTO? StockChange { get; set; }
    }
}
