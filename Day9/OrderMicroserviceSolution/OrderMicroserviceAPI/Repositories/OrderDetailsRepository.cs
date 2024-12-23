using Microsoft.EntityFrameworkCore;
using OrderMicroserviceAPI.Contexts;
using OrderMicroserviceAPI.Models;

namespace OrderMicroserviceAPI.Repositories
{
    public class OrderDetailsRepository : Repository<OrderDetails, int>
    {

        public OrderDetailsRepository(OrderContext orderContext)
        {
            _orderContext = orderContext;
        }
        public async override Task<ICollection<OrderDetails>> Get()
        {
            if (_orderContext.OrderDetails.Count() == 0)
            {
                throw new Exception("No entities found");
            }
            return await _orderContext.OrderDetails.ToListAsync();
        }

        public async override Task<OrderDetails> Get(int key)
        {
            return _orderContext.OrderDetails.Find(key) ??
                throw new Exception("Entity not found");
        }
    }
}
