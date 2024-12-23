using OrderMicroserviceAPI.Models.DTOs;
using OrderMicroserviceAPI.Models;

namespace OrderMicroserviceAPI.Interfaces
{
    public interface IOrderService
    {
        public Task<Order> AddOrder(OrderDetailsDTO orderDetails);
        public Task<OrderDetailsDTO> GetOrder(int orderId);
        public Task<OrderDetailsDTO> UpdateOrder(int orderId, OrderDetailsDTO orderDetails);
        public Task<OrderDetailsDTO> DeleteOrder(int orderId);
    }
}
