using AutoMapper;
using UserManagementAPI.Models.DTOs;
using UserManagementAPI.Models;

//namespace UserManagementAPI.Mapper
//{
//    public class MappingProfile
//    {
//    }
//}


namespace UserManagementAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // User to UserResponseDto mapping
            CreateMap<User, UserResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UId))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()));

            // RegisterRequestDto to User mapping
            CreateMap<RegisterRequestDto, User>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                //.ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                //.ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role));

            // LoginRequestDto to User mapping (optional, but useful for internal logic)
            CreateMap<LoginRequestDto, User>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username));
        }
    }
}
