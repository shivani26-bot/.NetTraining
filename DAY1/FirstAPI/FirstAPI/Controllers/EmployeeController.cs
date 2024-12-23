using System.Runtime.CompilerServices;
using FirstAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        //[HttpGet]
        //public string Get()
        //{
        //    return "hello world";
        //}
        //[HttpPost]
        //public string Post()
        //{
        //    return "This is the post method";
        //}



        //Employee employee = new Employee();
        //[HttpGet]
        ////when we try to make a get request we get a object pointing to null 
        ////this is because when we make a call to action method in API, it creates a controller object, execute respective action method, generate the response, and drops controller object 
        //public Employee Get()
        //{
        //    return employee;
        //}
        //[HttpPost]
        ////object is passed into the body of the object 
        //public Employee Post(Employee employee)
        //{
        //    this.employee = employee;
        //    return employee;
        //}



        //to fix the above mistake 
        //static Employee employee = new Employee();
        //[HttpGet]
        ////now we get the object which we posted using post method 
        //public Employee Get()
        //{
        //    return employee;
        //}
        //[HttpPost]
        //public Employee Post(Employee employee)
        //{
        //    EmployeeController.employee = employee;
        //    return employee;
        //}



        //        static List<Employee> employees = new List<Employee>()
        //        {
        //            new Employee{Id=1, Name="Ramu", Age=25, Salary=235454.4f}
        //        };
        //        [HttpGet]
        ////        //here we get the list of employee object 
        //// [
        ////  {
        ////    "id": 0,
        ////    "name": "string",
        ////    "age": 0,
        ////    "salary": 0
        ////  }
        ////]
        //        public IEnumerable<Employee> Get()
        //        {
        //            return employees;
        //        }
        //        [HttpPost]
        //        public Employee Post(Employee employee)
        //        {
        //            employees.Add(employee);
        //            return employee;
        //        }
        //if we post a employee detail 
        //        [
        //  {
        //    "id": 1,
        //    "name": "Ramu",
        //    "age": 25,
        //    "salary": 235454.4
        //  },
        //  {
        //    "id": 2,
        //    "name": "Priya",
        //    "age": 28,
        //    "salary": 986876
        //  }
        //]

        static List<Employee> employees = new List<Employee>()
        {
            new Employee{Id=1, Name="Ramu", Age=25, Salary=235454.4f}
        };
        [HttpGet]
        //        //here we get the list of employee object 
        // [
        //  {
        //    "id": 0,
        //    "name": "string",
        //    "age": 0,
        //    "salary": 0
        //  }
        //]
        public IEnumerable<Employee> Get()
        {
            return employees;
        }
        [HttpPost]
        public Employee Post(Employee employee)
        {
            employee.Id = employees[employees.Count - 1].Id + 1;
            employees.Add(employee);
            return employee;
        }
        [HttpPut]
        //pass employee_id as perameter and employee as FromBodyAttribute 
        public Employee Edit(int employee_id, Employee employee)
        {
            int idx = -1;
            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].Id == employee_id)
                {
                    idx = i;
                    break;
                }
            }
            if (idx > 0)
            {
                employees[idx]=employee;
            }
            return employee;

        }
        [HttpDelete]
        public void Delete(int employee_id)
        {
            int idx = -1;
            for(int i = 0; i < employees.Count; i++)
            {
                if (employees[i].Id == employee_id)
                {
                    idx = i;
                    break;
                }
            }
            if (idx > 0)
            {
                employees.RemoveAt(idx);
            }
        }
    }
}
