using AutoMapper;
using ShoppingAPI.Models.DTO;
using ShoppingAPI.Models;
namespace ShoppingAPI.Mapper
{
    public class SupplierProfile:Profile
    {
        public SupplierProfile() {
            CreateMap<Supplier, SupplierBasicDTO>()
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ContactPerson));
            CreateMap<SupplierBasicDTO, Supplier>()
                .ForMember(dest => dest.ContactPerson, opt => opt.MapFrom(src => src.Name));

          

        }
    }
}
