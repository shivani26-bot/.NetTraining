
using AuditLogMicroservice.Contexts;
using AuditLogMicroservice.Interfaces;
using AuditLogMicroservice.Models;
using AuditLogMicroservice.Repositories;
using AuditLogMicroservice.Services;
using Microsoft.EntityFrameworkCore;

namespace AuditLogMicroservice
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
            builder.Services.AddDbContext<AuditContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            #endregion

            #region Repositories
            builder.Services.AddScoped<IRepository<AuditLog, int>, AuditLogRepository>();
            #endregion

            #region Services
            builder.Services.AddScoped<IAuditLogService, AuditLogService>();
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
