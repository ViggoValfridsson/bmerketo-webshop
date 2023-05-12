using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bmerketo_webshop.Migrations
{
    /// <inheritdoc />
    public partial class OnSaleColumnForProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "OriginalPrice");

            migrationBuilder.AddColumn<decimal>(
                name: "CurrentPrice",
                table: "Products",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "SalePercentage",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentPrice",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SalePercentage",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "OriginalPrice",
                table: "Products",
                newName: "Price");
        }
    }
}
