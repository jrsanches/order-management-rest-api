using Microsoft.EntityFrameworkCore;

namespace OrderManagement.Infrastructure
{
    public class OrderManagementSeeder
    {
        public static void Seed(OrderManagementContext context)
        {
            SeedProducts(context);
        }

        private static void SeedProducts(OrderManagementContext context)
        {
            if (context.Products.Any())
                return;

            var query = @"
                INSERT INTO [dbo].[Products]
                           ([Name]
                           ,[Price])
                     VALUES
                           ('Apple Iphone 12'
                           ,200);

                INSERT INTO [dbo].[Products]
                           ([Name]
                           ,[Price])
                     VALUES
                           ('Samsung S22'
                           ,300);";

            context.Database.ExecuteSqlRaw(query);
        }

    }
}
