using ShoppingAPI.Contexts;
using ShoppingAPI.Exceptions;
using ShoppingAPI.Models;

namespace ShoppingAPI.Repositories
{
    //public class ProductRepositoryV2
    //{
    //}

    public class ProductRepositoryV2 : Repository<Product, int>
    {
        public ProductRepositoryV2(ShoppingContext shoppingContext)
        {
            _shoppingContext = shoppingContext;
        }
        public override ICollection<Product> Get()
        {
            var products = _shoppingContext.Products.ToList();
            if (products.Count == 0)
            {
                throw new RepositoryEmptyException("No products found");
            }
            return products;
        }
        public override Product Get(int key)
        {
            var product = _shoppingContext.Products.FirstOrDefault(p => p.Id == key);
            if (product == null)
            {
                throw new EntityNotFoundException("Product not found");
            }
            return product;
        }
    }
}
