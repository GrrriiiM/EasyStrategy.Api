using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyStrategy.Api.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GrouperAggregations",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrouperAggregations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GrouperTypes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false),
                    ParentId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrouperTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrouperTypes_GrouperTypes_ParentId",
                        column: x => x.ParentId,
                        principalTable: "GrouperTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Groupers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    TypeId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groupers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groupers_GrouperTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "GrouperTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GrouperAggregationGroupers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    GrouperAggregationId = table.Column<long>(nullable: false),
                    GrouperId = table.Column<long>(nullable: false),
                    GrouperAggregationId1 = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrouperAggregationGroupers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrouperAggregationGroupers_GrouperAggregations_GrouperAggreg~",
                        column: x => x.GrouperAggregationId,
                        principalTable: "GrouperAggregations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GrouperAggregationGroupers_GrouperAggregations_GrouperAggre~1",
                        column: x => x.GrouperAggregationId1,
                        principalTable: "GrouperAggregations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GrouperAggregationGroupers_Groupers_GrouperId",
                        column: x => x.GrouperId,
                        principalTable: "Groupers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GrouperAggregationGroupers_GrouperAggregationId",
                table: "GrouperAggregationGroupers",
                column: "GrouperAggregationId");

            migrationBuilder.CreateIndex(
                name: "IX_GrouperAggregationGroupers_GrouperAggregationId1",
                table: "GrouperAggregationGroupers",
                column: "GrouperAggregationId1");

            migrationBuilder.CreateIndex(
                name: "IX_GrouperAggregationGroupers_GrouperId",
                table: "GrouperAggregationGroupers",
                column: "GrouperId");

            migrationBuilder.CreateIndex(
                name: "IX_Groupers_TypeId",
                table: "Groupers",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GrouperTypes_ParentId",
                table: "GrouperTypes",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GrouperAggregationGroupers");

            migrationBuilder.DropTable(
                name: "GrouperAggregations");

            migrationBuilder.DropTable(
                name: "Groupers");

            migrationBuilder.DropTable(
                name: "GrouperTypes");
        }
    }
}
