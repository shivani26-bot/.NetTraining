

using System.ComponentModel.DataAnnotations;

namespace EmployeeMicroservice.Models
{
    public class Employee : IEquatable<Employee>
    {
        [Key]
        public int EId { get; set; } //only if we give field as Id, it's bydefault taken as primary key
        public string EName { get; set; } = string.Empty;
        public int Age { get; set; }
        public string City { get; set; } = string.Empty;

        public bool Equals(Employee? other)
        {
            if (other == null) return false;
            return EId == other.EId;
        }
    }
}
