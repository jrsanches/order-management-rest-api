using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using OrderManagement.Api.Extensions;
using OrderManagement.Infrastructure;
using OrderManagement.Infrastructure.Extensions;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers()
    .AddJsonOptions(options => { options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });

builder.Services.ConfigureDatabase(builder.Configuration);

builder.Services.ConfigureDependencyInjection();
builder.Services.ConfigureApiDocumentation();
builder.Services.ConfigureAuthentication(builder.Configuration);



var app = builder.Build();

app.Services.EnsureDatabaseSetup();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureExceptionHandler();

app.UseHttpsRedirection();

app.UseOpenApiDocumentation();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapGet("/", () => Results.Redirect("/swagger")).ExcludeFromDescription();

app.Run();
