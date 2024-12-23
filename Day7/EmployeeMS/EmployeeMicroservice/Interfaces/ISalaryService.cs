using EmployeeMicroservice.Models.DTOs;

namespace EmployeeMicroservice.Interfaces
{
    public interface ISalaryService
    {

        public Task<SalaryDTO> LogSalary(SalaryDTO salary);
    }
}
