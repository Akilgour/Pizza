using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pizza.RepositoryCore.Migrations
{
    public partial class PizzaOrderStats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PizzaOrder",
                table: "PizzaOrder");

            migrationBuilder.RenameTable(
                name: "PizzaOrder",
                newName: "PizzaOrders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PizzaOrders",
                table: "PizzaOrders",
                column: "Id");

            migrationBuilder.Sql(
                @"CREATE OR ALTER VIEW[dbo].[PizzaOrderStats]
AS
SELECT        TOP(100) PERCENT SizeInCM, BaseType, SauceType, Created, LastModified, Id, GivenName, OrderFor_SurName, dbo.PizzaOrderCountBySurName(OrderFor_SurName) AS TotalOrders
FROM            dbo.PizzaOrders
ORDER BY GivenName, OrderFor_SurName"

                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW [dbo].[PizzaOrderStats]");

               migrationBuilder.DropPrimaryKey(
                name: "PK_PizzaOrders",
                table: "PizzaOrders");

            migrationBuilder.RenameTable(
                name: "PizzaOrders",
                newName: "PizzaOrder");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PizzaOrder",
                table: "PizzaOrder",
                column: "Id");
        }
    }
}
