using EmployeeMicroservice.Filters;
using EmployeeMicroservice.Interfaces;
using EmployeeMicroservice.Models;
using EmployeeMicroservice.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [CustomExceptionFilter]
    public class EmployeesController : ControllerBase
    {

       
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
       
     
        [HttpPost]
        public async Task<IActionResult> GetEmployees(EmployeeRequestDTO employeeRequestDTO)
        { 
            var employees = await _employeeService.GetAllEmployees(employeeRequestDTO);
            return Ok(employees);
        }

        [HttpPost("NewEmployee")]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            var newEmployee = await _employeeService.AddEmployee(employee);
            return Ok(newEmployee);
        }
    }
}
