using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(); // Add controller services to the container.

// Register the Swagger generator, defining 1 or more Swagger documents.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // You can provide configuration options here
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "My API",
        Version = "v1",
        Description = "A simple example ASP.NET Core Web API"
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Enable middleware to serve generated Swagger as a JSON endpoint.
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); // Specify the Swagger JSON endpoint
        c.RoutePrefix = string.Empty; // Set the Swagger UI at the app's root
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();
