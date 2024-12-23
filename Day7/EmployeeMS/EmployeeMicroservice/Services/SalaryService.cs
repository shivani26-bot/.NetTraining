using EmployeeMicroservice.Interfaces;
using EmployeeMicroservice.Models;
using EmployeeMicroservice.Models.DTOs;
using Newtonsoft.Json;

namespace EmployeeMicroservice.Services
{
    public class SalaryService : ISalaryService
    {

        HttpClient _httpClient;
        //protected readonly IRepository<int, Employee> _repository;
        public SalaryService(IRepository<int, Employee> repository)
        {
            _httpClient = new HttpClient();
            //_repository = repository;
        }

        //public  async Task<Employee> AddEmployee(Employee employee)
        //{
        //    var addedEmployee = await _repository.Add(employee);

        //    return addedEmployee;
        //}
        public async Task<SalaryDTO> LogSalary(SalaryDTO salary){

            //request url where we should make request , here we are trying to call salarygmicroservice from employeemicroservice 
            //we can get the url by running salarymicroservice by running post request we can see the request url
            var response = await _httpClient.PostAsJsonAsync("http://localhost:5066/api/Salary", salary);
            if (response.IsSuccessStatusCode)
            {
                var responsedata = await response.Content.ReadAsStringAsync();
                var salaryData = JsonConvert.DeserializeObject<SalaryDTO>(responsedata);
                return salaryData;
            }
            throw new Exception("Error while adding modification to auditlog");
        }

     
    }
}
