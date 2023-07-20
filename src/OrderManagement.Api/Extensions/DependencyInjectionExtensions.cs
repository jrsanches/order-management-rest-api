using OrderManagement.Infrastructure;
using OrderManagement.Infrastructure.Repositories;
using OrderManagement.Model.Interfaces;
using OrderManagement.Model.Interfaces.Repositories;

namespace OrderManagement.Api.Extensions
{
    internal static class DependencyInjectionExtensions
    {
        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            //services.AddTransient<SmartAcJwtService>();
            //services.AddTransient<IAuthorizationHandler, ValidTokenAuthorizationHandler>();

            //services.AddScoped<DeviceReadingAlertService>();
            //services.AddScoped<DateTimeProvider>();
        }
    }
}
