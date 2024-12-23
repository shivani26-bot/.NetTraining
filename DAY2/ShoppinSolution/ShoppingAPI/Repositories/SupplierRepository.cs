using ShoppingAPI.Contexts;
using ShoppingAPI.Exceptions;
using ShoppingAPI.Interfaces;
using ShoppingAPI.Models;

namespace ShoppingAPI.Repositories
{
    public class SupplierRepository : Repository<Supplier, string>
    {
     public SupplierRepository(ShoppingContext context)
        {
            _shoppingContext = context;
        }
        public override ICollection<Supplier> Get()
        {
            var suppliers = _shoppingContext.Suppliers.ToList();
            if (suppliers.Count == 0)
            {
                throw new RepositoryEmptyException("NO suppliers in database");
            }
            return suppliers;
        }

        public override Supplier Get(string key)
        {
            var supplier = _shoppingContext.Suppliers.SingleOrDefault(suppliers => suppliers.SupplierId == key);
            if (supplier == null)
            {
                throw new EntityNotFoundException("No supplier with the given id");
            }
            return supplier;
        }
    }
}
