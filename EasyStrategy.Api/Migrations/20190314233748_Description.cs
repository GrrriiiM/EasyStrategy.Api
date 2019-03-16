using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyStrategy.Api.Migrations
{
    public partial class Description : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GrouperAggregationGroupers_GrouperAggregations_GrouperAggre~1",
                table: "GrouperAggregationGroupers");

            migrationBuilder.DropColumn(
                name: "GrouperAggregationId1",
                table: "GrouperAggregationGroupers");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "GrouperAggregations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "GrouperAggregations");

            migrationBuilder.AddColumn<long>(
                name: "GrouperAggregationId1",
                table: "GrouperAggregationGroupers",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GrouperAggregationGroupers_GrouperAggregations_GrouperAggre~1",
                table: "GrouperAggregationGroupers",
                column: "GrouperAggregationId1",
                principalTable: "GrouperAggregations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
