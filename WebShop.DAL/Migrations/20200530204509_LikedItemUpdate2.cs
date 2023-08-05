using Microsoft.EntityFrameworkCore.Migrations;

namespace WebShop.DAL.Migrations
{
    public partial class LikedItemUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LikedItems_Customers_CustomerId",
                table: "LikedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_LikedItems_Products_ProductId",
                table: "LikedItems");

            migrationBuilder.DropIndex(
                name: "IX_LikedItems_CustomerId",
                table: "LikedItems");

            migrationBuilder.DropIndex(
                name: "IX_LikedItems_ProductId",
                table: "LikedItems");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "LikedItems",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "LikedItems",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "LikedItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "LikedItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_LikedItems_CustomerId",
                table: "LikedItems",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_LikedItems_ProductId",
                table: "LikedItems",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_LikedItems_Customers_CustomerId",
                table: "LikedItems",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LikedItems_Products_ProductId",
                table: "LikedItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
