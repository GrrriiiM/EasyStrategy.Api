using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyStrategy.Api.Migrations
{
    public partial class sale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReferenceGrouperId",
                table: "Sales",
                newName: "ReferenceId");

            migrationBuilder.RenameColumn(
                name: "ReferenceGrouperDescription",
                table: "Sales",
                newName: "ReferenceDescription");

            migrationBuilder.AddColumn<long>(
                name: "GrouperId",
                table: "Sales",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_GrouperId",
                table: "Sales",
                column: "GrouperId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_ReferenceId",
                table: "Sales",
                column: "ReferenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Groupers_GrouperId",
                table: "Sales",
                column: "GrouperId",
                principalTable: "Groupers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Groupers_GrouperId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_GrouperId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_ReferenceId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "GrouperId",
                table: "Sales");

            migrationBuilder.RenameColumn(
                name: "ReferenceId",
                table: "Sales",
                newName: "ReferenceGrouperId");

            migrationBuilder.RenameColumn(
                name: "ReferenceDescription",
                table: "Sales",
                newName: "ReferenceGrouperDescription");
        }
    }
}
