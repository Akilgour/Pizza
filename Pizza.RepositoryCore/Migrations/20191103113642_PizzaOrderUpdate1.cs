using Microsoft.EntityFrameworkCore.Migrations;

namespace Pizza.RepositoryCore.Migrations
{
    public partial class PizzaOrderUpdate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderFor_GivenName",
                table: "PizzaOrder",
                newName: "GivenName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GivenName",
                table: "PizzaOrder",
                newName: "OrderFor_GivenName");
        }
    }
}
