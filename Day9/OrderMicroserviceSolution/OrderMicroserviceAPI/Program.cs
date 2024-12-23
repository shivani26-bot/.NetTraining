
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using OrderMicroserviceAPI.Contexts;
using OrderMicroserviceAPI.Interfaces;
using OrderMicroserviceAPI.Models;
using OrderMicroserviceAPI.Repositories;
using OrderMicroserviceAPI.Services;

namespace OrderMicroserviceAPI
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




            //builder.Services.AddDbContext<OrderContext>(options =>
            //{
            //    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            //});

            //builder.Services.AddScoped<IRepository<Order, int>, OrderRepository>();
            //builder.Services.AddScoped<IRepository<OrderDetails, int>, OrderDetailsRepository>();

            //builder.Services.AddScoped<IOrderService, OrderService>();


            builder.Services.AddDbContext<OrderContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<IRepository<Order, int>, OrderRepository>();
            builder.Services.AddScoped<IRepository<OrderDetails, int>, OrderDetailsRepository>();

            builder.Services.AddScoped<IOrderService, OrderService>();

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
