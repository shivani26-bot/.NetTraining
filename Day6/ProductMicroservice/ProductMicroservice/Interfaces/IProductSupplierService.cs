using ProductMicroservice.Models;
using ProductMicroservice.Models.DTOs;

namespace ProductMicroservice.Interfaces
{
    public interface IProductSupplierService : IProductCommonService
    {
        public Task<Product> AddProduct(Product product);
        public Task<Product> UpdateProductPrice(ProductPriceUpdateRequestDTO product);
        public Task<Product> UpdateProductStock(ProductStockUpdateRequestDTO product);
    }
}
