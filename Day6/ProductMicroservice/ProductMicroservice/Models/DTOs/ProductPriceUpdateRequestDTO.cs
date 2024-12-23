namespace ProductMicroservice.Models.DTOs
{
    public class ProductPriceUpdateRequestDTO
    {
        public int ProductId { get; set; }
        public float NewPrice { get; set; }
    }
}
