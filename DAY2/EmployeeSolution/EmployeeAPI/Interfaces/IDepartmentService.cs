//using EmployeeAPI.Migrations;
using EmployeeAPI.Models;
using EmployeeAPI.Models.DTOs;

namespace EmployeeAPI.Interfaces
{
    public interface IDepartmentService
    {
        public List<Department> GetDepartments();
        public DepartmentDTO AddDepartment(DepartmentDTO departmentDTO);
    }
}
