using System.Collections.Generic;
using EmployeeMicroservice.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMicroservice.Contexts
{
    public class EmployeeContext : DbContext
    {
     
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

    }


}
