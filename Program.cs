using BackupServer.API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHealthChecks()
    .AddDbContextCheck<BackupServerContext>("Database");
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
      
        options.JsonSerializerOptions.PropertyNamingPolicy =
            System.Text.Json.JsonNamingPolicy.CamelCase;

        options.JsonSerializerOptions.ReferenceHandler =
            System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });


builder.Services.AddOpenApi();

var connectionString = builder.Configuration
    .GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<BackupServerContext>(options =>
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString)
    ));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowRazorPages", policy =>
    {
        policy.WithOrigins(
                "http://localhost:5001",
                "http://localhost:8080"
              )
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    // Dostępne pod: http://localhost:5000/openapi/v1.json
    app.MapOpenApi();
}

app.MapHealthChecks("/health/db");
app.UseCors("AllowRazorPages");
app.UseAuthorization();
app.MapControllers();

app.MapGet("/health", () => new
{
    status = "healthy",
    timestamp = DateTime.UtcNow,
    service = "BackupServer API"
});

app.Run();