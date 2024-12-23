
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using SalaryMicroservice.Contexts;
using SalaryMicroservice.Interfaces;
using SalaryMicroservice.Models;
using SalaryMicroservice.Repositories;
using SalaryMicroservice.Service;

namespace SalaryMicroservice
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



            #region Contexts
            builder.Services.AddDbContext<SalaryContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            #endregion


            #region Repositories
            builder.Services.AddScoped<IRepository<Salary, int>, SalaryRepository>();
            #endregion

            #region Services
            builder.Services.AddScoped<ISalaryService, SalaryService>();
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
