using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiExample.Migrations
{
    /// <inheritdoc />
    public partial class productSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Name", "Description", "Price", "Quantity", "Category", "IsActive", "IsOnSale" },
                values: new object[,]
                {
                    { "Product 1", "Description of product 1", 10.00m, 100, "Category 1", true, false },
                    { "Product 2", "Description of product 2", 20.00m, 200, "Category 1", true, false },
                    { "Product 3", "Description of product 3", 30.00m, 300, "Category 2", true, false },
                    { "Product 4", "Description of product 4", 40.00m, 400, "Category 2", true, false },
                    { "Product 5", "Description of product 5", 50.00m, 500, "Category 3", true, false }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Name",
                keyValues: new object[] { "Product 1" });
            
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Name",
                keyValues: new object[] { "Product 2" });
            
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Name",
                keyValues: new object[] { "Product 3" });
            
            migrationBuilder.DeleteData( 
                table: "Products",
                keyColumn: "Name",
                keyValues: new object[] { "Product 4" });
            
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Name",
                keyValues: new object[] { "Product 5" });
            
        }
    }
}
