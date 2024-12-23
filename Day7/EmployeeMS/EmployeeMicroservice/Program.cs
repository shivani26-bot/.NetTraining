
using EmployeeMicroservice.Contexts;
using EmployeeMicroservice.Filters;
using EmployeeMicroservice.Interfaces;
using EmployeeMicroservice.Models;
using EmployeeMicroservice.Repositories;
using EmployeeMicroservice.Services;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMicroservice
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



            #region context
            builder.Services.AddDbContext<EmployeeContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            #endregion


            #region repositories
            builder.Services.AddScoped<IRepository<int, Employee>, EmployeeRepository>();
            #endregion

            #region services
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();

            builder.Services.AddScoped<ISalaryService, SalaryService>();
            #endregion

            #region Filters
            builder.Services.AddScoped<CustomExceptionFilter>();
            #endregion

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
