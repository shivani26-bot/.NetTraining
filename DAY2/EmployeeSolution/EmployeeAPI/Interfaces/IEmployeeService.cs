using EmployeeAPI.Models;
using EmployeeAPI.Models.DTOs;

namespace EmployeeAPI.Interfaces
{
    public interface IEmployeeService
    {
        public List<Employee> GetEmployees();
       public bool UpdateEmployeeDepartment(UpdateEmployeeDepartmentDTO updateEmployeeDepartment);

        public Employee AddEmployee(Employee employee);
        //public AddEmployeeDTO AddEmployee(AddEmployeeDTO employee);
        public Employee UpdatePhone(EmployeePhoneUpdateRequestDTO employeeDto);
        public Employee UpdateSalary(EmployeeSalaryUpdateRequestDTO employeeDto);
    }
}
