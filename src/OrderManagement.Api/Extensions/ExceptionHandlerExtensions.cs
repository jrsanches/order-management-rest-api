using Microsoft.AspNetCore.Diagnostics;

namespace OrderManagement.Api.Extensions
{
    internal static class ExceptionHandlerExtensions
    {
        public static void ConfigureExceptionHandler(this WebApplication app)
        {
            app.UseExceptionHandler(c => c.Run(async context =>
            {
                var exception = context.Features
                    .Get<IExceptionHandlerPathFeature>()?.Error;

                var logger = context.Request.HttpContext.RequestServices
                    .GetRequiredService<ILogger<WebApplication>>();

                logger.LogError(exception, exception?.Message);

                await context.Response.WriteAsJsonAsync(new { error = "Something went wrong." });
            }));
        }
    }
}
