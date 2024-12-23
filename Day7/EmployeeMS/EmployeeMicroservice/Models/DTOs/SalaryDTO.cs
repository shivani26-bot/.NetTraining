using System.ComponentModel.DataAnnotations;

namespace EmployeeMicroservice.Models.DTOs
{
    public class SalaryDTO
    {

    
        public int EId { get; set; }
        public float Basic { get; set; }
        public float Allowance { get; set; }
        public float Deductions { get; set; }
    }
}
