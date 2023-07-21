using OrderManagement.Api.Providers;
using OrderManagement.Infrastructure;
using OrderManagement.Infrastructure.Interfaces;

namespace OrderManagement.Api.Extensions
{
    internal static class DependencyInjectionExtensions
    {
        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ContextUserDataProvider>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
