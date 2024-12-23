using ShoppingAPI.Models.DTO;

namespace ShoppingAPI.Interfaces
{
    public interface ICategoryService
    {
        public ICollection<CategoryProductDTO> GetCategories();
    }
}
