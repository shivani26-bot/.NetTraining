namespace ShoppingAPI.Models.DTO
{

    //To update price or stock , no need to send heavy object as Product together , hence we can model class in order to sent the essental data 
    //to update price 
    public class ProductPriceUpdateRequestDTO
    {
        public int Id { get; set; }
        public float UpdatedPrice { get; set; }
    }
}
