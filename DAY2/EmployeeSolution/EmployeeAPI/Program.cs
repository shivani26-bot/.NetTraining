
using EmployeeAPI.Contexts;
using EmployeeAPI.Interfaces;
using EmployeeAPI.Models;
using EmployeeAPI.Repositories;
using EmployeeAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.



            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            #region Mappers
            builder.Services.AddAutoMapper(typeof(Department));
            builder.Services.AddAutoMapper(typeof(Employee));
            #endregion

            builder.Services.AddDbContext<EmployeeContext>(opts =>
            {
                opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddScoped<IRepository<Employee, int>, EmployeeRepository>();
            builder.Services.AddScoped<IDepartmentRepository<Department, int>, DepartmentRepository>();
           
            builder.Services.AddScoped<IDepartmentService,DepartmentService>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
