using SalaryMicroservice.Interfaces;
using SalaryMicroservice.Models;

namespace SalaryMicroservice.Service
{
    public class SalaryService : ISalaryService
    {
        private readonly IRepository<Salary, int> _salaryRepository;

        public SalaryService(IRepository<Salary, int> salaryRepository)
        {
            _salaryRepository = salaryRepository;
        }
        
        public Salary AddSalary(Salary salary)
        {
            var sal = _salaryRepository.Add(salary);
            return sal;
        }

        //public bool Delete(DateTime date)
        //{
        //    var logs = _auditLogRepository.Get().Where(a => a.ModifiedAt.Date <= date.Date).ToList();
        //    if (logs.Count == 0)
        //    {
        //        return false;
        //    }
        //    foreach (var log in logs)
        //    {
        //        _auditLogRepository.Delete(log.LogId);
        //    }
        //    return true;
        //}

        public ICollection<Salary> GetSalary()
        {
            var sal = _salaryRepository.Get();
            return sal;
        }
    }

}


