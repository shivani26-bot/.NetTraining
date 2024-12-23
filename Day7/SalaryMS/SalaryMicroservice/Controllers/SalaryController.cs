using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalaryMicroservice.Interfaces;
using SalaryMicroservice.Models;

namespace SalaryMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryController : ControllerBase
    {
        private readonly ISalaryService _salaryService;

        public SalaryController(ISalaryService salaryService)
        {
            _salaryService = salaryService;
        }
        [HttpPost]
        [ProducesResponseType(typeof(Salary), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDTO), StatusCodes.Status400BadRequest)]
        public ActionResult<ICollection<Salary>> AddSalary(Salary salary)
        {
            try
            {
                var sal = _salaryService.AddSalary(salary);
                return Ok(sal);
            }
            catch (Exception e)
            {

                return BadRequest(new ErrorDTO { ErrorNumber = 400, ErrorMessage = e.Message });
            }
        }
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<Salary>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDTO), StatusCodes.Status404NotFound)]
        public ActionResult<ICollection<Salary>> GetSalary()
        {
            try
            {
                var sal = _salaryService.GetSalary();
                return Ok(sal);
            }
            catch (Exception e)
            {

                return BadRequest(new ErrorDTO { ErrorNumber = 400, ErrorMessage = e.Message });
            }
        }
    }
    }
