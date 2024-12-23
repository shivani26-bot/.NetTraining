using SagaOrchestratorAPI.Interfaces;
using SagaOrchestratorAPI.Models;

namespace SagaOrchestratorAPI.Services
{
    public class OrderService : IOrderService
    {
        HttpClient _httpClient;

        public OrderService()
        {
            _httpClient = new HttpClient();
        }
        public async Task<int> AddOrder(OrderDetailsDTO orderDetails)
        {
            using (_httpClient = new HttpClient())
            {
        
                var response = await _httpClient.PostAsJsonAsync("http://localhost:5019/api/Order", orderDetails);
                if (response.IsSuccessStatusCode)
                {
                    var id = (await response.Content.ReadFromJsonAsync<Order>()).OrderId;
                    return id;
                }
            }
            throw new Exception("Failed to add order");
        }

        public async Task<bool> DeleteOrder(int orderId)
        {
            using (_httpClient = new HttpClient())
            {
                var response = await _httpClient.DeleteAsync($"http://localhost:5019/api/Order/{orderId}");
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
