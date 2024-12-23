using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;

namespace SalaryMicroservice.Contexts
{
    public class SalaryContext : DbContext
    {
        public SalaryContext(DbContextOptions<SalaryContext> options) : base(options)
        {
        }

        public DbSet<SalaryMicroservice.Models.Salary> Salaries { get; set; }
    }
}
