using System.ComponentModel.DataAnnotations;

namespace SalaryMicroservice.Models
{
    public class Salary : IEquatable<Salary>
    {
        [Key]
        public int SId { get; set; } //salaryId

        public int EId { get; set; }
        public float Basic { get; set;  }
        public float Allowance { get; set; }
        public float Deductions { get; set; }

        public bool Equals(Salary? other)
        {
            if (other == null) return false;
            return SId == other.SId;
        }

    }
}
