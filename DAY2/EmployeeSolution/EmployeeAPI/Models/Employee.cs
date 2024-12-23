using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeAPI.Models
{
    public class Employee:IEquatable<Employee>
    {
        public int Id {  get; set; }
        public string Name { get; set; }= string.Empty;
        public int Age { get; set; }
        //public string Department { get; set; }
      

        public string PhoneNumber { get; set; } = string.Empty;
        public float Salary { get; set; }

        public bool Equals(Employee? other) //parameter is nullable product object
        {
            if (other == null) return false;
            Employee p1 = this;
            Employee p2 = other;
            return p1.Id == p2.Id;

        }

        public int? DepartmentId { get; set; } //foreign key
        [ForeignKey("DepartmentId")]
        public Department? Department { get; set; } // navigation property
    }
}
