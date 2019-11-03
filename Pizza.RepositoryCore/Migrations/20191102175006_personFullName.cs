using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pizza.RepositoryCore.Migrations
{
    public partial class personFullName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "OrderFor_Created",
                table: "PizzaOrder",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "OrderFor_GivenName",
                table: "PizzaOrder",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderFor_LastModified",
                table: "PizzaOrder",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "OrderFor_SurName",
                table: "PizzaOrder",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderFor_Created",
                table: "PizzaOrder");

            migrationBuilder.DropColumn(
                name: "OrderFor_GivenName",
                table: "PizzaOrder");

            migrationBuilder.DropColumn(
                name: "OrderFor_LastModified",
                table: "PizzaOrder");

            migrationBuilder.DropColumn(
                name: "OrderFor_SurName",
                table: "PizzaOrder");
        }
    }
}
