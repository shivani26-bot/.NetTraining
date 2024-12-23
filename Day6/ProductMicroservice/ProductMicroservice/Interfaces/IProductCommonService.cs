using ProductMicroservice.Models.DTOs;
using ProductMicroservice.Models;

namespace ProductMicroservice.Interfaces
{
    public interface IProductCommonService
    {
       public Task<IEnumerable<Product>> GetAllProducts(ProductRequestDTO productsRequestDTO);

       
    }
}
