namespace ProductMicroservice.Models.DTOs
{
    public class Pagination
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 5;
    }
    public class ProductPriceFilter
    {
        public float MinPrice { get; set; } = 0;
        public float MaxPrice { get; set; } = 0;
    }
    public class ProductStockFilter
    {
        public int MinStock { get; set; } = 0;
        public int MaxStock { get; set; } = 0;
    }
    public class ProductAvailabilityFilter
    {
        public Status Availability { get; set; } = Status.Unavailable;
    }
    public class ProductImageFilter
    {
        public bool IsImageAvailable { get; set; } = false;
    }

    public class ProductRequestDTO
    {
        public ProductPriceFilter? PriceFilter { get; set; }
        public ProductStockFilter? StockFilter { get; set; }
        public ProductAvailabilityFilter? AvailabilityFilter { get; set; }
        public ProductImageFilter? ImageFilter { get; set; }
        public Pagination? Pagination { get; set; }

        //Sort by price ascending 1, descending -1
        //sort by stock ascending 2, descending -2
        //sort by availability ascending 3
        public int? SortOrder { get; set; }
        public ProductRequestDTO()
        {
            PriceFilter = new ProductPriceFilter();
            StockFilter = new ProductStockFilter();
            AvailabilityFilter = new ProductAvailabilityFilter();
            ImageFilter = new ProductImageFilter();
            Pagination = new Pagination();
        }
    }
}
