using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyStrategy.Api.Migrations
{
    public partial class sales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReferenceColorRGB",
                table: "GrouperTypes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReferenceIcon",
                table: "GrouperTypes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReferenceColorRGB",
                table: "Groupers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReferenceIcon",
                table: "Groupers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SaleIntervalTypes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleIntervalTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IntervalTypeId = table.Column<long>(nullable: true),
                    IntervalBegin = table.Column<DateTime>(nullable: false),
                    IntervalEnd = table.Column<DateTime>(nullable: false),
                    GrouperAggregationId = table.Column<long>(nullable: true),
                    GrouperTypeId = table.Column<long>(nullable: true),
                    ReferenceGrouperId = table.Column<long>(nullable: false),
                    ReferenceGrouperDescription = table.Column<string>(nullable: true),
                    Value = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_GrouperAggregations_GrouperAggregationId",
                        column: x => x.GrouperAggregationId,
                        principalTable: "GrouperAggregations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sales_GrouperTypes_GrouperTypeId",
                        column: x => x.GrouperTypeId,
                        principalTable: "GrouperTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sales_SaleIntervalTypes_IntervalTypeId",
                        column: x => x.IntervalTypeId,
                        principalTable: "SaleIntervalTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SaleTargets",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IntervalTypeId = table.Column<long>(nullable: true),
                    IntervalBegin = table.Column<DateTime>(nullable: false),
                    IntervalEnd = table.Column<DateTime>(nullable: false),
                    GrouperAggregationId = table.Column<long>(nullable: true),
                    GrouperTypeId = table.Column<long>(nullable: true),
                    ReferenceGrouperId = table.Column<long>(nullable: false),
                    ReferenceGrouperDescription = table.Column<string>(nullable: true),
                    Target = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleTargets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleTargets_GrouperAggregations_GrouperAggregationId",
                        column: x => x.GrouperAggregationId,
                        principalTable: "GrouperAggregations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaleTargets_GrouperTypes_GrouperTypeId",
                        column: x => x.GrouperTypeId,
                        principalTable: "GrouperTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaleTargets_SaleIntervalTypes_IntervalTypeId",
                        column: x => x.IntervalTypeId,
                        principalTable: "SaleIntervalTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sales_GrouperAggregationId",
                table: "Sales",
                column: "GrouperAggregationId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_GrouperTypeId",
                table: "Sales",
                column: "GrouperTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_IntervalTypeId",
                table: "Sales",
                column: "IntervalTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleTargets_GrouperAggregationId",
                table: "SaleTargets",
                column: "GrouperAggregationId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleTargets_GrouperTypeId",
                table: "SaleTargets",
                column: "GrouperTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleTargets_IntervalTypeId",
                table: "SaleTargets",
                column: "IntervalTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "SaleTargets");

            migrationBuilder.DropTable(
                name: "SaleIntervalTypes");

            migrationBuilder.DropColumn(
                name: "ReferenceColorRGB",
                table: "GrouperTypes");

            migrationBuilder.DropColumn(
                name: "ReferenceIcon",
                table: "GrouperTypes");

            migrationBuilder.DropColumn(
                name: "ReferenceColorRGB",
                table: "Groupers");

            migrationBuilder.DropColumn(
                name: "ReferenceIcon",
                table: "Groupers");
        }
    }
}
