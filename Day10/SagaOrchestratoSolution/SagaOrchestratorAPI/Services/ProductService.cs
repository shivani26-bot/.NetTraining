using SagaOrchestratorAPI.Interfaces;
using SagaOrchestratorAPI.Models;

namespace SagaOrchestratorAPI.Services
{
    public class ProductService : IProductService
    {
        HttpClient _httpClient;
        public ProductService()
        {
            _httpClient = new HttpClient();
        }
        public async Task<Product> UpdateProduct(UpdateProductRequestDTO product)
        {
            var response = await _httpClient.PutAsJsonAsync("https://localhost:7278/api/Products", product);
            if (response.IsSuccessStatusCode)
            {
                var resultProduct = await response.Content.ReadFromJsonAsync<Product>();
                return resultProduct ?? throw new Exception("Failed to update product"); ;
            }
            throw new Exception("Failed to update product");
        }
    }
}
