
using System.Text;
using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProductMicroservice.Contexts;
using ProductMicroservice.Filters;
using ProductMicroservice.Interfaces;
using ProductMicroservice.Models;
using ProductMicroservice.Repositories;
using ProductMicroservice.Services;

namespace ProductMicroservice
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

            builder.Services.AddMemoryCache();
            builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting"));
            builder.Services.AddInMemoryRateLimiting();
            builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();


            #region AuthenticationFilter
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Keys:TokenKey"] ?? "")),
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        ValidateAudience = false,
                        ValidateIssuer = false
                    };
                });
            #endregion


            #region context
            builder.Services.AddDbContext<ProductContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            #endregion


            #region repositories
            builder.Services.AddScoped<IRepository<int, Product>, ProductRepository>();
            #endregion

            #region services
            //builder.Services.AddScoped<IProductCommonService, ProductService>();
            builder.Services.AddScoped<IProductSupplierService, ProductSupplierService>();
            builder.Services.AddScoped<IAuditLogService, AuditLogService>();
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

            app.UseIpRateLimiting();
            //app.UseHttpsRedirection();
           
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
