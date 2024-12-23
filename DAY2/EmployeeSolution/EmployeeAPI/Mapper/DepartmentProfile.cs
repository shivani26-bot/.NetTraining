using AutoMapper;
using EmployeeAPI.Models;
using EmployeeAPI.Models.DTOs;

namespace EmployeeAPI.Mapper
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {

            // src->department.cs, dest->departmentdto
            CreateMap<Department,DepartmentDTO>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DepartmentId))
                 .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.DepartmentName)).ReverseMap();
          

        }

        }
    }
