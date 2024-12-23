namespace SagaOrchestratorAPI.Models
{
    public class ProductPriceUpdateRequestDTO
    {
        public int ProdcutId { get; set; }
        public float NewPrice { get; set; }
    }
    public class ProductStockUpdateRequestDTO
    {
        public int ProductId { get; set; }
        public int StockToBeAdded { get; set; }
    }
    public class UpdateProductRequestDTO
    {
        public ProductPriceUpdateRequestDTO? PriceUpdate { get; set; }
        public ProductStockUpdateRequestDTO? StockUpdate { get; set; }

    }
}
