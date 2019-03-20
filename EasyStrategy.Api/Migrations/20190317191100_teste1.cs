using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyStrategy.Api.Migrations
{
    public partial class teste1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GrouperTypes_GrouperTypes_ParentId",
                table: "GrouperTypes");

            migrationBuilder.DropIndex(
                name: "IX_GrouperTypes_ParentId",
                table: "GrouperTypes");

            migrationBuilder.RenameColumn(
                name: "ReferenceGrouperId",
                table: "SaleTargets",
                newName: "ReferenceId");

            migrationBuilder.RenameColumn(
                name: "ReferenceGrouperDescription",
                table: "SaleTargets",
                newName: "ReferenceDescription");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "GrouperTypes",
                newName: "ChildId");

            migrationBuilder.AddColumn<long>(
                name: "GrouperId",
                table: "SaleTargets",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "GrouperTypeId",
                table: "Groupers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SaleTargets_GrouperId",
                table: "SaleTargets",
                column: "GrouperId");

            migrationBuilder.CreateIndex(
                name: "IX_GrouperTypes_ChildId",
                table: "GrouperTypes",
                column: "ChildId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groupers_GrouperTypeId",
                table: "Groupers",
                column: "GrouperTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groupers_GrouperTypes_GrouperTypeId",
                table: "Groupers",
                column: "GrouperTypeId",
                principalTable: "GrouperTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GrouperTypes_GrouperTypes_ChildId",
                table: "GrouperTypes",
                column: "ChildId",
                principalTable: "GrouperTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleTargets_Groupers_GrouperId",
                table: "SaleTargets",
                column: "GrouperId",
                principalTable: "Groupers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groupers_GrouperTypes_GrouperTypeId",
                table: "Groupers");

            migrationBuilder.DropForeignKey(
                name: "FK_GrouperTypes_GrouperTypes_ChildId",
                table: "GrouperTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleTargets_Groupers_GrouperId",
                table: "SaleTargets");

            migrationBuilder.DropIndex(
                name: "IX_SaleTargets_GrouperId",
                table: "SaleTargets");

            migrationBuilder.DropIndex(
                name: "IX_GrouperTypes_ChildId",
                table: "GrouperTypes");

            migrationBuilder.DropIndex(
                name: "IX_Groupers_GrouperTypeId",
                table: "Groupers");

            migrationBuilder.DropColumn(
                name: "GrouperId",
                table: "SaleTargets");

            migrationBuilder.DropColumn(
                name: "GrouperTypeId",
                table: "Groupers");

            migrationBuilder.RenameColumn(
                name: "ReferenceId",
                table: "SaleTargets",
                newName: "ReferenceGrouperId");

            migrationBuilder.RenameColumn(
                name: "ReferenceDescription",
                table: "SaleTargets",
                newName: "ReferenceGrouperDescription");

            migrationBuilder.RenameColumn(
                name: "ChildId",
                table: "GrouperTypes",
                newName: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_GrouperTypes_ParentId",
                table: "GrouperTypes",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_GrouperTypes_GrouperTypes_ParentId",
                table: "GrouperTypes",
                column: "ParentId",
                principalTable: "GrouperTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
