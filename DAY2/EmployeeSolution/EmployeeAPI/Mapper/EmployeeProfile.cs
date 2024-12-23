using AutoMapper;
using EmployeeAPI.Models.DTOs;
using EmployeeAPI.Models;

namespace EmployeeAPI.Mapper
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {

            // src->Employee.cs, dest->UpdateEmployeeDepartmentDTO
            CreateMap<Employee, UpdateEmployeeDepartmentDTO>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DepartmentId))
                 .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.DepartmentId)).ReverseMap();


        }

    }
}
