namespace ProductMicroservice.Models.DTOs
{
    public class ProductStockUpdateRequestDTO
    {
        public int ProductId { get; set; }
        public int StockToBeAdded { get; set; }
    }
}
