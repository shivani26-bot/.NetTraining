namespace EmployeeAPI.Models
{
    public class Department : IEquatable<Department>
    {
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; } = string.Empty;

       

        public bool Equals(Department? other) //parameter is nullable product object
        {
            if (other == null) return false;
     Department p1 = this;
            Department p2 = other;
            return p1.DepartmentId == p2.DepartmentId;

        }

        public ICollection<Employee>? Employees { get; set; }//navigation property
    }
}
