using Microsoft.EntityFrameworkCore.Migrations;

namespace WebShop.DAL.Migrations
{
    public partial class MigrationSizeNameChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sizes",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "Size",
                table: "Products",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Size",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "Sizes",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
