using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pizza.RepositoryCore.Migrations
{
    public partial class BaseModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PizzaOrder",
                table: "PizzaOrder");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PizzaOrder");

            migrationBuilder.AddColumn<Guid>(
                name: "foo",
                table: "PizzaOrder",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_PizzaOrder",
                table: "PizzaOrder",
                column: "foo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PizzaOrder",
                table: "PizzaOrder");

            migrationBuilder.DropColumn(
                name: "foo",
                table: "PizzaOrder");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "PizzaOrder",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_PizzaOrder",
                table: "PizzaOrder",
                column: "Id");
        }
    }
}
