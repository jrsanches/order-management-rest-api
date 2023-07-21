using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateOrderProc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var createProcSql = @"
                CREATE OR ALTER PROC sp_CreateOrder
                    (@CustomerId INT
                    ,@ProductId INT
                    ,@QuantityOfProducts INT) 
                AS 

                INSERT INTO [dbo].[Orders]
                           ([CustomerId]
                           ,[ProductId]
                           ,[QuantityOfProducts]
                           ,[TotalCost])
                     VALUES
                           (@CustomerId
                           ,@ProductId
                           ,@QuantityOfProducts
                           ,(SELECT TOP 1 (P.Price * @QuantityOfProducts) FROM Products P WHERE P.Id = @ProductId))
            ";

            migrationBuilder.Sql(createProcSql);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var dropProcSql = "DROP PROC sp_CreateOrder";

            migrationBuilder.Sql(dropProcSql);
        }
    }
}
