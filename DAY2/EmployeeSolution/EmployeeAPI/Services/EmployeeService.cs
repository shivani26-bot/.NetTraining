using System.Diagnostics;
using AutoMapper;
using EmployeeAPI.Interfaces;
using EmployeeAPI.Models;
using EmployeeAPI.Models.DTOs;
using EmployeeAPI.Repositories;

namespace EmployeeAPI.Services
{


    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee, int> _employeeRepository;
        private readonly IDepartmentRepository<Department, int> _departmentRepository;
        private readonly IMapper _mapper;
        public EmployeeService(IRepository<Employee, int> employeeRepository,
            IDepartmentRepository<Department, int>departmentRepository
            , IMapper mapper) //Taking the injection
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _departmentRepository = departmentRepository;

        }

        public Employee AddEmployee(Employee employee)
        {
            if (employee == null) throw new Exception("Unable to add product, product is null");
            //if (employee.PricePerUnit <= 0) throw new Exception("Unable to add product,price is less than or equal to zero ");
            //if (employee.StockAvailable < 0) throw new Exception("Unable to add product,stock is less than zero ");
            var newEmployee = _employeeRepository.Add(employee);
            return newEmployee;
        }

        //public AddEmployeeDTO AddEmployee(AddEmployeeDTO employee)
        //{
        //    if (employee == null) throw new Exception("Unable to add product, product is null");
        //    var newEmployee= new Employee
        //    //if (employee.PricePerUnit <= 0) throw new Exception("Unable to add product,price is less than or equal to zero ");
        //    //if (employee.StockAvailable < 0) throw new Exception("Unable to add product,stock is less than zero ");
        //    var newEmployee = _employeeRepository.Add(employee);
        //    return newEmployee;
        //}


        public Employee UpdatePhone(EmployeePhoneUpdateRequestDTO employeeDto)
        {
            if (employeeDto == null) throw new Exception("Unable to update price, employee data is null");
            if (employeeDto.UpdatedPhone=="" ) throw new Exception("Unable to update phone number,phone number is empty");
            var employee = _employeeRepository.GetEmployeeById(employeeDto.Id);
            //var auditLog = CreateAuditLog("Unit Price", product.PricePerUnit.ToString(), productDto.UpdatedPrice.ToString());
            if (employee == null) throw new Exception("Unable to update phone number, employee not found");
            employee.PhoneNumber = employeeDto.UpdatedPhone;
            employee = _employeeRepository.Update(employeeDto.Id, employee);
            //make a call to auditlog once we update the price 
            //_auditLogService.AddAuditLog(auditLog);
            return employee;
        }


        public Employee UpdateSalary(EmployeeSalaryUpdateRequestDTO employeeDto)
        {
            if (employeeDto == null) throw new Exception("Unable to update salary, employee data  is null");
            if (employeeDto.UpdatedSalary <= 0) throw new Exception("Unable to update salary, salary is less than or equal to zero");
            var employee = _employeeRepository.GetEmployeeById(employeeDto.Id);
            //var auditLog = CreateAuditLog("Stock Available", product.StockAvailable.ToString(), (product.StockAvailable + productDto.ChangeInStock).ToString());
            if (employee == null) throw new Exception("Unable to update salary, employee not found");
            employee.Salary = employeeDto.UpdatedSalary;
            employee = _employeeRepository.Update(employeeDto.Id, employee);
            //_auditLogService.AddAuditLog(auditLog);
            return employee;
        }

   

        public List<Employee> GetEmployees()
        {
            var employees = _employeeRepository.Get().OrderBy(p => p.Age);//sorting the products based on price in ascending order
            return employees.ToList();
        }

     

        public bool UpdateEmployeeDepartment(UpdateEmployeeDepartmentDTO updateEmployeeDepartment)
        {
            var employee = _employeeRepository.GetEmployeeById(updateEmployeeDepartment.Id);
            //Id-> employeeid
            if (employee == null)
            {
                throw new Exception("Employee not found");
            }

            var department = _departmentRepository.GetDepartmentById(updateEmployeeDepartment.DepartmentId);
       if (department == null){
                throw new Exception("Employee not found");
            }

       employee.DepartmentId = updateEmployeeDepartment.DepartmentId;
            _employeeRepository.UpdateEmployee(employee);
            
            return true;
            //return employee;

                }

        //public AddEmployeeDTO AddEmployee(AddEmployeeDTO employee)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
