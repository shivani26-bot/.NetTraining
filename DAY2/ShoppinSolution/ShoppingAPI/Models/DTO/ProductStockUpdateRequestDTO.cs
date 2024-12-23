namespace ShoppingAPI.Models.DTO
{

    //to update stock 
    public class ProductStockUpdateRequestDTO
    {
        public int Id { get; set; }
        public int ChangeInStock { get; set; }
    }
}
