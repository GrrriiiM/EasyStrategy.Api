using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyStrategy.Api.Migrations
{
    public partial class teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SaleTargets");

            migrationBuilder.CreateTable(
                name: "SaleValueTypes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleValueTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SaleNumberValues",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SaleId = table.Column<long>(nullable: true),
                    ValueTypeId = table.Column<long>(nullable: true),
                    Value = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleNumberValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleNumberValues_Sales_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaleNumberValues_SaleValueTypes_ValueTypeId",
                        column: x => x.ValueTypeId,
                        principalTable: "SaleValueTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SaleNumberValues_SaleId",
                table: "SaleNumberValues",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleNumberValues_ValueTypeId",
                table: "SaleNumberValues",
                column: "ValueTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SaleNumberValues");

            migrationBuilder.DropTable(
                name: "SaleValueTypes");

            migrationBuilder.CreateTable(
                name: "SaleTargets",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    GrouperAggregationId = table.Column<long>(nullable: true),
                    GrouperId = table.Column<long>(nullable: true),
                    GrouperTypeId = table.Column<long>(nullable: true),
                    IntervalBegin = table.Column<DateTime>(nullable: false),
                    IntervalEnd = table.Column<DateTime>(nullable: false),
                    IntervalTypeId = table.Column<long>(nullable: true),
                    ReferenceDescription = table.Column<string>(nullable: true),
                    ReferenceId = table.Column<long>(nullable: false),
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
                        name: "FK_SaleTargets_Groupers_GrouperId",
                        column: x => x.GrouperId,
                        principalTable: "Groupers",
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
                name: "IX_SaleTargets_GrouperAggregationId",
                table: "SaleTargets",
                column: "GrouperAggregationId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleTargets_GrouperId",
                table: "SaleTargets",
                column: "GrouperId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleTargets_GrouperTypeId",
                table: "SaleTargets",
                column: "GrouperTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleTargets_IntervalTypeId",
                table: "SaleTargets",
                column: "IntervalTypeId");
        }
    }
}
