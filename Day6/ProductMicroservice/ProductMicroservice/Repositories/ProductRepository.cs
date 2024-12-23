using Microsoft.EntityFrameworkCore;
using ProductMicroservice.Contexts;
using ProductMicroservice.Interfaces;
using ProductMicroservice.Models;

namespace ProductMicroservice.Repositories
{
    public class ProductRepository : IRepository<int, Product>
    {
        private readonly ProductContext _context;
  
        public ProductRepository(ProductContext context)
        {
            _context = context;
        }
        public async Task<Product> Add(Product entity)
        {
            _context.Products.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Product> Delete(int id)
        {
            var product = await GetById(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            if (_context.Products.Any())
            {
                return await _context.Products.ToListAsync();
            }
            throw new Exception("No products found");
        }

        public async Task<Product> GetById(int id)
        {
            var product = await _context.Products.SingleOrDefaultAsync(p => p.Id == id);
            if (product == null)
                throw new Exception("No Product found with the given id");
            return product;
        }

        public async Task<Product> Update(Product entity)
        {
            var product = await GetById(entity.Id);
            if (product != null)
            {
                _context.Products.Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            throw new Exception("No Product found with the given id");
        }
    }
}
