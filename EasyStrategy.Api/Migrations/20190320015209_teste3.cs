using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyStrategy.Api.Migrations
{
    public partial class teste3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleNumberValues_Sales_SaleId",
                table: "SaleNumberValues");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleNumberValues_Sales_SaleId",
                table: "SaleNumberValues",
                column: "SaleId",
                principalTable: "Sales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleNumberValues_Sales_SaleId",
                table: "SaleNumberValues");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleNumberValues_Sales_SaleId",
                table: "SaleNumberValues",
                column: "SaleId",
                principalTable: "Sales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
