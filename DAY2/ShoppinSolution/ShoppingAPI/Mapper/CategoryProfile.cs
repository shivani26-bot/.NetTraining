using AutoMapper;
using ShoppingAPI.Models;
using ShoppingAPI.Models.DTO;

namespace ShoppingAPI.Mapper
{
    public class CategoryProfile:Profile
    {

        public CategoryProfile()
        {
            CreateMap<Category, CategoryProductDTO>().ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.CategoryName))
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products)).ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();

        }
    }
}
