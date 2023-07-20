using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace OrderManagement.Infrastructure.Extensions
{
    public static class DatabaseExtensions
    {
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrderManagementContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("OrderManagement"));
            });
        }

        public static void EnsureDatabaseSetup(this IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var services = scope.ServiceProvider;
            var db = services.GetRequiredService<OrderManagementContext>();
            db.Database.EnsureCreated();
            OrderManagementSeeder.Seed(db);
        }
    }
}
