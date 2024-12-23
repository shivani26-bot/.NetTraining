using SalaryMicroservice.Models;

namespace SalaryMicroservice.Interfaces
{
    public interface ISalaryService
    {

        public Salary AddSalary(Salary salary);
        public ICollection<Salary> GetSalary();
    }
}
