using Microsoft.EntityFrameworkCore.Migrations;

namespace Pizza.RepositoryCore.Migrations
{
    public partial class PizzaOrderCountBySurName_Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"CREATE FUNCTION[dbo].[PizzaOrderCountBySurName](@surName nvarchar(max))
                RETURNS int AS
                BEGIN
                    DECLARE @ret int;
                    SELECT @ret = Count(*)
                    FROM[Pizza].[dbo].[PizzaOrder]
                    WHERE OrderFor_SurName = @surName;
                    RETURN @ret;
                END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION [dbo].[PizzaOrderCountBySurName]");
        }
    }
}
