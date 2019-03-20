using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyStrategy.Api.Migrations
{
    public partial class teste2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "Sales");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Value",
                table: "Sales",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
