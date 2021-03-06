﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyStrategy.Api.Migrations
{
    public partial class groupertype_order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Groupers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "Groupers");
        }
    }
}
