//using EmployeeAPI.Interfaces;
//using EmployeeAPI.Models;
//using EmployeeAPI.Models.DTOs;
//using EmployeeAPI.Services;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace EmployeeAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class EmployeeController : ControllerBase
//    {
//        private readonly IEmployeeService _employeeService;
//        public EmployeeController(IEmployeeService employeeService)
//        {
//            _employeeService = employeeService;
//        }
//        [HttpGet]
//        [ProducesResponseType(typeof(ICollection<Employee>), StatusCodes.Status200OK)]
//        [ProducesResponseType(typeof(ErrorDTO), StatusCodes.Status400BadRequest)]
//        public ActionResult<ICollection<Employee>> GetEmployees()
//        {
//            try
//            {
//                var employees = _employeeService.GetEmployees();
//                return Ok(employees);
//            }
//            catch (Exception e)
//            {
//                return BadRequest(new ErrorDTO { ErrorNumber = 400, ErrorMessage = e.Message });
//            }
//        }



//        [HttpPost]
//        [ProducesResponseType(typeof(Employee), StatusCodes.Status201Created)]
//        [ProducesResponseType(typeof(ErrorDTO), StatusCodes.Status400BadRequest)]
//        public ActionResult<Employee> AddEmployee(Employee employee)
//        {
//            try
//            {
//                var newemployee = _employeeService.AddEmployee(employee);
//                return Created("", newemployee);
//            }
//            catch (Exception e)
//            {

//                return BadRequest(new ErrorDTO { ErrorNumber = 400, ErrorMessage = e.Message });
//            }
//        }

//        [HttpPut]
//        //annotation to update swagger document in order to show success and failure messages
//        //indexer order to customize bad request we can use error object as ErrorDTO 
//        [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
//        [ProducesResponseType(typeof(ErrorDTO), StatusCodes.Status400BadRequest)]
//        public ActionResult<Employee> UpdateEmployee(UpdateEmployeeDTO employeeDto)
//        {
//            string message = "";
//            try
//            {
//                if (employeeDto.PhoneNumberChange != null)
//                {
//                    var updatedPhone = _employeeService.UpdatePhone(employeeDto.PhoneNumberChange);
//                    return Ok(updatedPhone);
//                }
//                else if (employeeDto.SalaryChange != null)
//                {
//                    var updatedSalary = _employeeService.UpdateSalary(employeeDto.SalaryChange);
//                    return Ok(updatedSalary);
//                }
//            }
//            catch (Exception e)
//            {
//                message = e.Message;
//            }
//            return BadRequest(new ErrorDTO { ErrorNumber = 400, ErrorMessage = message });
//        }

//        }

//    }

//        //public IActionResult GetEmployees()
//        //{
//        //    var employees = _employeeService.GetEmployees();
//        //    return Ok(employees);
//        //}
//    }


    //public class EmployeeController : ControllerBase
    //{
    //    //private readonly IProductGeneralService _productService;
    //    //public ProductController(IProductGeneralService productService)
    //    //{
    //    //    _productService= productService;
    //    //}
    //    //[HttpGet]
    //    //public IActionResult GetProducts()
    //    //{
    //    //    var products=_productService.GetProducts();
    //    //    return Ok(products);
    //    //}

    //    private readonly IProductSupplierService _productService;

    //    public EmployeeController(IProductSupplierService productService)
    //    {
    //        _productService = productService;
    //    }

    //    [HttpGet]
    //    public ActionResult<ICollection<Product>> GetProducts()
    //    {
    //        try
    //        {
    //            var products = _productService.GetProducts();
    //            return Ok(products);
    //        }
    //        catch (Exception e)
    //        {

    //            return BadRequest(e.Message);
    //        }
    //    }
    //    [HttpPost]
    //    public ActionResult<Product> AddProduct(Product product)
    //    {
    //        try
    //        {
    //            var newProduct = _productService.AddProduct(product);
    //            return Created("", newProduct);
    //        }
    //        catch (Exception e)
    //        {

    //            return BadRequest(e.Message);
    //        }
    //    }

    //}
//}
using EmployeeAPI.Interfaces;
using EmployeeAPI.Models;
using EmployeeAPI.Models.DTOs;
using EmployeeAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<Employee>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDTO), StatusCodes.Status400BadRequest)]
        public ActionResult<ICollection<Employee>> GetEmployees()
        {
            try
            {
                var employees = _employeeService.GetEmployees();
                return Ok(employees);
            }
            catch (Exception e)
            {
                return BadRequest(new ErrorDTO { ErrorNumber = 400, ErrorMessage = e.Message });
            }
        }



        [HttpPost]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorDTO), StatusCodes.Status400BadRequest)]
        public ActionResult<Employee> AddEmployee(Employee employee)
        {
            try
            {
                var newemployee = _employeeService.AddEmployee(employee);
                return Created("", newemployee);
            }
            catch (Exception e)
            {

                return BadRequest(new ErrorDTO { ErrorNumber = 400, ErrorMessage = e.Message });
            }
        }

        [HttpPut]
        //annotation to update swagger document in order to show success and failure messages
        //indexer order to customize bad request we can use error object as ErrorDTO 
        [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDTO), StatusCodes.Status400BadRequest)]
        public ActionResult<Employee> UpdateEmployee(UpdateEmployeeDTO employeeDto)
        {
            string message = "";
            try
            {
                if (employeeDto.PhoneNumberChange != null)
                {
                    var updatedPhone = _employeeService.UpdatePhone(employeeDto.PhoneNumberChange);
                    return Ok(updatedPhone);
                }
                else if (employeeDto.SalaryChange != null)
                {
                    var updatedSalary = _employeeService.UpdateSalary(employeeDto.SalaryChange);
                    return Ok(updatedSalary);
                }
            }
            catch (Exception e)
            {
                message = e.Message;
            }
            return BadRequest(new ErrorDTO { ErrorNumber = 400, ErrorMessage = message });
        }

        [HttpPut("update-department")]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDTO), StatusCodes.Status400BadRequest)]
        public ActionResult UpdateEmployeeDepartment(UpdateEmployeeDepartmentDTO updateEmployeeDepartment)
        {

            string message = "";
            if (updateEmployeeDepartment==null || updateEmployeeDepartment.DepartmentId <= 0)
            {
                return BadRequest(new { message = "Invalid input data" });
            }
            try
            {
                var result = _employeeService.UpdateEmployeeDepartment(updateEmployeeDepartment);
                if (!result)
                {
                    return NotFound(new { message = "employee not found" });
                }
                return Ok(new { message = "employee department updated successfully" });
            }
            catch (Exception e)
            {
                message = e.Message;
            }
            return BadRequest(new ErrorDTO { ErrorNumber = 400, ErrorMessage = message });

        }

    }

        //public IActionResult GetEmployees()
        //{
        //    var employees = _employeeService.GetEmployees();
        //    return Ok(employees);
        //}
    }


    //public class EmployeeController : ControllerBase
    //{
    //    //private readonly IProductGeneralService _productService;
    //    //public ProductController(IProductGeneralService productService)
    //    //{
    //    //    _productService= productService;
    //    //}
    //    //[HttpGet]
    //    //public IActionResult GetProducts()
    //    //{
    //    //    var products=_productService.GetProducts();
    //    //    return Ok(products);
    //    //}

    //    private readonly IProductSupplierService _productService;

    //    public EmployeeController(IProductSupplierService productService)
    //    {
    //        _productService = productService;
    //    }

    //    [HttpGet]
    //    public ActionResult<ICollection<Product>> GetProducts()
    //    {
    //        try
    //        {
    //            var products = _productService.GetProducts();
    //            return Ok(products);
    //        }
    //        catch (Exception e)
    //        {

    //            return BadRequest(e.Message);
    //        }
    //    }
    //    [HttpPost]
    //    public ActionResult<Product> AddProduct(Product product)
    //    {
    //        try
    //        {
    //            var newProduct = _productService.AddProduct(product);
    //            return Created("", newProduct);
    //        }
    //        catch (Exception e)
    //        {

    //            return BadRequest(e.Message);
    //        }
    //    }

    //}
//}
