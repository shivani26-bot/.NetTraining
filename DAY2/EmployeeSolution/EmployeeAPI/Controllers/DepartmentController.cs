using EmployeeAPI.Interfaces;
using EmployeeAPI.Models.DTOs;
using EmployeeAPI.Models;
using EmployeeAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {

        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        [HttpGet]

        [ProducesResponseType(typeof(ICollection<Employee>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDTO), StatusCodes.Status400BadRequest)]
        public ActionResult<ICollection<Employee>> GetDepartments()
        {
            try
            {
                var departments = _departmentService.GetDepartments();
                return Ok(departments);
            }
            catch (Exception e)
            {
                return BadRequest(new ErrorDTO { ErrorNumber = 400, ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(Department), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorDTO), StatusCodes.Status400BadRequest)]
        public ActionResult<DepartmentDTO> AddDepartment(DepartmentDTO departmentDto)

        {
            string message = "";
          
            try
            {
               var newdept=_departmentService.AddDepartment(departmentDto);
                return Created("", newdept);
               
            }
            catch (Exception e)
            {
                message = e.Message;
            }
            return BadRequest(new ErrorDTO { ErrorNumber = 400, ErrorMessage = message });
        }
        //public IActionResult GetDepartments()
        //{
        //    var departments = _departmentService.GetDepartments();
        //    return Ok(departments);
        //}
    }
}
