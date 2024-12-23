using Microsoft.EntityFrameworkCore;
using OrderMicroserviceAPI.Models;

namespace OrderMicroserviceAPI.Contexts
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
    }
}
