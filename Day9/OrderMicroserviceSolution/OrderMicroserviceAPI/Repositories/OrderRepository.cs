using Microsoft.EntityFrameworkCore;
using OrderMicroserviceAPI.Contexts;
using OrderMicroserviceAPI.Models;

namespace OrderMicroserviceAPI.Repositories
{
    public class OrderRepository : Repository<Order, int>
    {
        public OrderRepository(OrderContext orderContext)
        {
            _orderContext = orderContext;
        }
        public async override Task<ICollection<Order>> Get()
        {
            if (_orderContext.Orders.Count() == 0)
            {
                throw new Exception("No entities found");
            }
            return await _orderContext.Orders.ToListAsync();
        }

        public async override Task<Order> Get(int key)
        {
            var order = _orderContext.Orders.Find(key);
            if (order == null)
            {
                throw new Exception("Entity not found");
            }
            return order;
        }
    }
}
