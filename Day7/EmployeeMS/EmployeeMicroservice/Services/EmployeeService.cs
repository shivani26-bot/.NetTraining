using System.Text.RegularExpressions;
using EmployeeMicroservice.Interfaces;
using EmployeeMicroservice.Models;
using EmployeeMicroservice.Models.DTOs;

namespace EmployeeMicroservice.Services
{
    public class EmployeeService : IEmployeeService
    {
        //in order to inherit this class in other class make the repository as protected
        protected readonly IRepository<int, Employee> _repository;
        private readonly ISalaryService _salaryService;
        public EmployeeService(IRepository<int, Employee> repository, ISalaryService salaryService)
        {
            _repository = repository;
            _salaryService = salaryService;
        }
        public async Task<IEnumerable<Employee>> GetAllProducts(EmployeeRequestDTO employeeRequestDTO)
        {
            List<Employee> employees = new List<Employee>();
            employees = (await _repository.GetAll()).ToList();
            employees = FilterByAge(employees, employeeRequestDTO.AgeFilter);
            employees = FilterByCity(employees, employeeRequestDTO.CityFilter);

            employees = SortEmployees(employees, employeeRequestDTO.SortOrder);
            employees = PaginateEmployees(employees, employeeRequestDTO.Pagination);
            return employees;
        }
        private List<Employee> SortEmployees(List<Employee> employees, int? sortOrder)
        {
            //Sort by name ascending 1, descending -1
            //sort by age ascending 2, descending -2
            if (sortOrder == null)
            {
                return employees;
            }
            switch (sortOrder)
            {
                case 1:
                    employees = employees.OrderBy(p => p.EName).ToList();
                    break;
                case -1:
                    employees = employees.OrderByDescending(p => p.EName).ToList();
                    break;
                case 2:
                    employees = employees.OrderBy(p => p.Age).ToList();
                    break;
                case -2:
                    employees = employees.OrderByDescending(p => p.Age).ToList();
                    break;
             
                default:
                    break;
            }
            return employees;
        }

        private List<Employee> PaginateEmployees(List<Employee> products, Pagination? pagination)
        {
            if (pagination == null)
            {
                return products;
            }
            products = products.Skip((pagination.Page - 1) * pagination.PageSize).Take(pagination.PageSize).ToList();
            return products;
        }


        private List<Employee> FilterByAge(List<Employee> employees, EmployeeAgeFilter? ageFilter)
        {
            if (ageFilter == null)
            {
                return employees;
            }
            if (ageFilter.MaxAge > 0)
            {
                employees = employees.Where(p => p.Age <= ageFilter.MaxAge).ToList();
            }
            if (ageFilter.MinAge > 0)
            {
                employees = employees.Where(p => p.Age >= ageFilter.MinAge).ToList();
            }
            return employees;
        }
        private List<Employee> FilterByCity(List<Employee> employees, EmployeeCityFilter? cityFilter)
        {
            if (cityFilter == null)
            {
                return employees;
            }
        if(cityFilter.IsExactMatch)
            {//return employees that exactly match the city name

                employees = employees.Where(p => p.City.Equals(cityFilter.CityName, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            else
            {

               //return employees that partially match the city name
                employees = employees.Where(p => p.City.Contains(cityFilter.CityName, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            return employees;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees(EmployeeRequestDTO employeeRequestDTO)
        {
            List<Employee> employees = new List<Employee>();
            employees = (await _repository.GetAll()).ToList();
            employees = FilterByAge(employees, employeeRequestDTO.AgeFilter);
            employees = FilterByCity(employees, employeeRequestDTO.CityFilter);
  
            employees = SortEmployees(employees, employeeRequestDTO.SortOrder);
            employees = PaginateEmployees(employees, employeeRequestDTO.Pagination);
            return employees;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
           
            if (employee == null)
            {
                throw new Exception("Product cannot be null");
            }
            if (employee.Age <= 0)
            {
                throw new Exception("Age cannot be less than or equal to 0");
            }
            if (employee.City == string.Empty)
            {
                throw new Exception("City cannot be empty");
            }
            var addedEmployee = await _repository.Add(employee);
            var result = await InsertIntoSalaryLog(addedEmployee.EId, 80000,40000, 10000);
            return (addedEmployee);
        }

        private async Task<SalaryDTO> InsertIntoSalaryLog(int eid , float basic, float allowance, float deductions)
        {
            SalaryDTO salaryDTO = new SalaryDTO()
            {
                EId =eid,
               Basic = basic,
                Allowance =allowance,
                Deductions = deductions,
            };
            var result = await _salaryService.LogSalary(salaryDTO);
            if (result == null)
            {
                throw new Exception("Failed to log salary");
            }
            return result;
        }
    }
    }
     

 
    
