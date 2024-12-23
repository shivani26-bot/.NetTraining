using Microsoft.EntityFrameworkCore;
using ShoppingAPI.Models;

namespace ShoppingAPI.Contexts
{

    public class ShoppingContext : DbContext
    {
        public ShoppingContext(DbContextOptions options) : base(options)//initializes the connection string in the base class
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //seeding the tabel with data
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 101, Title = "Laptop", PricePerUnit = 45000, Description = "Lenovo Laptop", StockAvailable = 10 },
                new Product { Id = 102, Title = "Mobile", PricePerUnit = 15000, Description = "Samsung Mobile", StockAvailable = 20 },
                new Product { Id = 103, Title = "Tablet", PricePerUnit = 25000, Description = "Apple Tablet", StockAvailable = 5 },
                new Product { Id = 104, Title = "Smart Watch", PricePerUnit = 5000, Description = "MI Smart Watch", StockAvailable = 15 },
                new Product { Id = 105, Title = "Headphones", PricePerUnit = 2000, Description = "Boat Headphones", StockAvailable = 25 }
            );

            modelBuilder.Entity<Supplier>().HasData(
               new Supplier { SupplierId = "S101", SupplierName = "Lenovo", ContactPerson = "Ramu", Phone = 9876543210 },
               new Supplier { SupplierId = "S102", SupplierName = "Samsung", ContactPerson = "Somu", Phone = 8877665544 },
               new Supplier { SupplierId = "S103", SupplierName = "Apple", ContactPerson = "Bimu", Phone = 7766554433 },
               new Supplier { SupplierId = "S104", SupplierName = "MI", ContactPerson = "Monu", Phone = 2223334445 }
           );
            modelBuilder.Entity<Category>().HasData(
            new Category{ CategoryId = 1, CategoryName = "Laptop" },
                new Category{ CategoryId = 2, CategoryName = "Mobile" },
                new Category{ CategoryId = 3, CategoryName = "Tablet" }
         );
        }
    }
}
