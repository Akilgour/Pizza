using Microsoft.EntityFrameworkCore.Migrations;

namespace Pizza.RepositoryCore.Migrations
{
    public partial class PizzaOrderUpDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BaseType",
                table: "PizzaOrder",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SauceType",
                table: "PizzaOrder",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BaseType",
                table: "PizzaOrder");

            migrationBuilder.DropColumn(
                name: "SauceType",
                table: "PizzaOrder");
        }
    }
}
