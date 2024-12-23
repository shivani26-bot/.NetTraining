using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShoppingAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "PricePerUnit", "StockAvailable", "Title" },
                values: new object[,]
                {
                    { 101, "Lenovo Laptop", 45000f, 10, "Laptop" },
                    { 102, "Samsung Mobile", 15000f, 20, "Mobile" },
                    { 103, "Apple Tablet", 25000f, 5, "Tablet" },
                    { 104, "MI Smart Watch", 5000f, 15, "Smart Watch" },
                    { 105, "Boat Headphones", 2000f, 25, "Headphones" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 105);
        }
    }
}
