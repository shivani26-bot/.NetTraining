using AutoMapper;
using ShoppingAPI.Models.DTO;
using ShoppingAPI.Models;

namespace ShoppingAPI.Mapper
{
    public class ProductProfile:Profile
    {

        public ProductProfile()
        {
            CreateMap<Product, SupplierProductDTO>()
                .ForMember(dest => dest.SupplierId, opt => opt.MapFrom(src => src.Id));
            CreateMap<SupplierProductDTO, Product>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.SupplierId));
        }

    }
}
