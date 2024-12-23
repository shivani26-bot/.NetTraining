using AutoMapper;
using ShoppingAPI.Interfaces;
using ShoppingAPI.Models;
using ShoppingAPI.Models.DTO;
using ShoppingAPI.Repositories;

namespace ShoppingAPI.Services
{
    public class CategoryService:ICategoryService
    {
        private readonly IRepository<Category, int> _repository;
        private readonly IMapper _mapper;

        public CategoryService(IRepository<Category,int> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ICollection<CategoryProductDTO> GetCategories()
        {
            var categories = _repository.Get();
            IList<CategoryProductDTO> categoryProductDTOs=_mapper.Map<IList<CategoryProductDTO>>(categories);
            return categoryProductDTOs;
        }
    }
}
