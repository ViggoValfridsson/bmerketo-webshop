using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bmerketo_webshop.Migrations
{
    /// <inheritdoc />
    public partial class ProductImageRequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Products",
                type: "nvarchar(2048)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(2048)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Products",
                type: "nvarchar(2048)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2048)");
        }
    }
}
