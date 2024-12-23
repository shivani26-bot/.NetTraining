using Microsoft.EntityFrameworkCore;
using ShoppingAPI.Contexts;
using ShoppingAPI.Exceptions;
using ShoppingAPI.Models;

namespace ShoppingAPI.Repositories
{
    public class CategoryRepository:Repository<Category,int>
    {
        public CategoryRepository(ShoppingContext context)
        {
            _shoppingContext = context;
            
        }

        public override ICollection<Category> Get()
        {
            var categor1 = _shoppingContext.Categories.Include(c => c.Products).ToList();
            if (categor1.Count() == 0)
            {
                throw new RepositoryEmptyException("no suppliers in the database");
            }
            return categor1;

        }

        //get by id
        public override Category Get(int key)
        {
            var categor1 = _shoppingContext.Categories.FirstOrDefault(c => c.CategoryId == key);
            if (categor1 == null)
            {
                throw new EntityNotFoundException("no suppliers with given id");
            }
            return categor1;
        }
    }
}
