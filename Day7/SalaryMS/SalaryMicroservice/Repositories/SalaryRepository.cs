using Microsoft.AspNetCore.Components.Forms;
using SalaryMicroservice.Contexts;
using SalaryMicroservice.Interfaces;
using SalaryMicroservice.Models;

namespace SalaryMicroservice.Repositories
{
    public class SalaryRepository : Repository<Salary, int>
    {

        public SalaryRepository(SalaryContext salaryContext)
        {
            _salaryContext = salaryContext;
        }
        public override ICollection<Salary> Get()
        {
            var salaries = _salaryContext.Salaries.ToList();
            if (salaries.Count == 0)
            {
                throw new Exception("No logs found");
            }
            return salaries;
        }

    }


}
