using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyStrategy.Api.Migrations
{
    public partial class grouper_parent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ParentId",
                table: "Groupers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groupers_ParentId",
                table: "Groupers",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groupers_Groupers_ParentId",
                table: "Groupers",
                column: "ParentId",
                principalTable: "Groupers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groupers_Groupers_ParentId",
                table: "Groupers");

            migrationBuilder.DropIndex(
                name: "IX_Groupers_ParentId",
                table: "Groupers");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Groupers");
        }
    }
}
