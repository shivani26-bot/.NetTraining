using ShoppingAPI.Exceptions;
using ShoppingAPI.Interfaces;
using ShoppingAPI.Models;


namespace ShoppingAPI.Repositories
{
    public class ProductRepository : IRepository<Product, int>
    {
        static IDictionary<int, Product> products = new Dictionary<int, Product>()
        {
            {101, new Product{Id = 101, Title = "Laptop", PricePerUnit = 45000, Description = "Lenovo Laptop", StockAvailable = 10}},
            {102, new Product{Id = 102, Title = "Mobile", PricePerUnit = 15000, Description = "Samsung Mobile", StockAvailable = 20}},
            {103, new Product{Id = 103, Title = "Tablet", PricePerUnit = 25000, Description = "Apple Tablet", StockAvailable = 5}},
            {104, new Product{Id = 104, Title = "Smart Watch", PricePerUnit = 5000, Description = "MI Smart Watch", StockAvailable = 15} },
            {105, new Product{Id = 105, Title = "Headphones", PricePerUnit = 2000, Description = "Boat Headphones", StockAvailable = 25 } }
        };
        public Product Add(Product entity)
        {
            if (products.Values.Contains(entity))
            {
                throw new DuplicateEntityException("Product already exists in the repository");
            }
            int pid = GenerateProdcutID();
            entity.Id = pid;
            products.Add(pid, entity);
            return entity;
        }
      

        private int GenerateProdcutID()
        {
            if (products.Count == 0)
            {
                return 101;
            }
            return products.Keys.Max() + 1;
        }

        public Product Delete(int key)
        {
            var product = Get(key);
            if (product == null)
            {
                throw new EntityNotFoundException("Product not found in the repository");
            }
            products.Remove(key);
            return product;
        }

        public ICollection<Product> Get()
        {
            if (products.Count == 0)
            {
                throw new RepositoryEmptyException("No products found in the repository");
            }
            return products.Values;
        }

        public Product Get(int key)
        {
            Product? product = products.Keys.Contains(key) ? products[key] : null;
            if (product == null)
            {
                throw new EntityNotFoundException("Product not found in the repository");
            }
            return product;
        }

        public Product Update(int key, Product entity)
        {
            var product = Get(key);
            if (product == null)
            {
                throw new EntityNotFoundException("Product not found in the repository");
            }
            products[key] = entity;
            return entity;
        }
    }
}

