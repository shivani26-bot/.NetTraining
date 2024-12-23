using ShoppingAPI.Models.DTO;
using ShoppingAPI.Models;

namespace ShoppingAPI.Interfaces
{
    public interface IProductSupplierService : IProductGeneralService
    {
        //actions which can be performed by supplier 
        //IProductSupplierService can add, update price and stock of a product 
        public Product AddProduct(Product product);
        public Product UpdatePrice(ProductPriceUpdateRequestDTO productDto);
        public Product UpdateStock(ProductStockUpdateRequestDTO productDto);
    }
}
