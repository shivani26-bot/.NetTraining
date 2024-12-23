using SagaOrchestratorAPI.Models;

namespace SagaOrchestratorAPI.Interfaces
{
    public interface IOrderService
    {
        public Task<int> AddOrder(OrderDetailsDTO orderDetails);
        public Task<bool> DeleteOrder(int orderId);
    }
}
