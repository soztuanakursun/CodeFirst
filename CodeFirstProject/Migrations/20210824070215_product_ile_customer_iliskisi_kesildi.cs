using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstProject.Migrations
{
    public partial class product_ile_customer_iliskisi_kesildi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Products_ProductId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_ProductId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Customers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ProductId",
                table: "Customers",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Products_ProductId",
                table: "Customers",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
