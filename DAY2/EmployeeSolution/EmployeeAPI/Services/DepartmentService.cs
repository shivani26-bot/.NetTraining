using AutoMapper;
using EmployeeAPI.Interfaces;
using EmployeeAPI.Models;
using EmployeeAPI.Models.DTOs;
using EmployeeAPI.Repositories;

namespace EmployeeAPI.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository<Department, int> _departmentRepository;
        private readonly IMapper _mapper;
        public DepartmentService(IDepartmentRepository<Department, int> departmentRepository, IMapper mapper) //Taking the injection
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }
        public DepartmentDTO AddDepartment(DepartmentDTO departmentDTO)
        {
           
            var newDepartment = _mapper.Map<Department>(departmentDTO);
            //Map<Department>(departmentDTO)->Departmentdto is converted to department
            var depart= _departmentRepository.Add(newDepartment);
            return _mapper.Map<DepartmentDTO>(depart);
          
        }

        public List<Department> GetDepartments()
        {
            var departments = _departmentRepository.Get();//sorting the products based on price in ascending order
            return departments.ToList();
        }
    }
}
