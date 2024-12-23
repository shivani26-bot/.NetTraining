using SagaOrchestratorAPI.Models;

namespace SagaOrchestratorAPI.Interfaces
{
    public interface IProductService
    {
        public Task<Product> UpdateProduct(UpdateProductRequestDTO product);
    }
}
