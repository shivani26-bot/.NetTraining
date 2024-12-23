using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using EmployeeAPI.Models;

namespace EmployeeAPI.Contexts
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions options) : base(options)//initializes the connection string in the base class
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //seeding the tabel with data
            modelBuilder.Entity<Employee>().HasData(
    new Employee { Id = 101, Name = "Aditya", Age = 30, PhoneNumber = "9873489344", Salary = 50000 },
          new Employee { Id = 102, Name = "Payal", Age = 28, PhoneNumber = "9873435364", Salary = 40000 },
          new Employee { Id = 103, Name = "Pranay", Age = 35, PhoneNumber = "9866689347", Salary = 80000 },
          new Employee { Id = 104, Name = "Kavita", Age = 32, PhoneNumber = "9879999341", Salary = 70000 },
          new Employee { Id = 105, Name = "Reema", Age = 25, PhoneNumber = "9873489234", Salary = 90000 }
            );

            modelBuilder.Entity<Department>().HasData(
           new Department { DepartmentId = 1, DepartmentName = "HR"  },
           new Department { DepartmentId = 2, DepartmentName = "IT" },
           new Department { DepartmentId = 3, DepartmentName = "SALES" },
           new Department { DepartmentId = 4, DepartmentName = "PRODUCT"  }
       );
        }
    }


}
