using EmployeeMicroservice.Models;
using EmployeeMicroservice.Models.DTOs;

namespace EmployeeMicroservice.Interfaces
{
    public interface IEmployeeService
    {
        public Task<IEnumerable<Employee>> GetAllEmployees(EmployeeRequestDTO employeesRequestDTO);
        public Task<Employee> AddEmployee(Employee employee);
    }
}
