using FuelRoute.Core.Interfaces;
using FuelRoute.Infrastructure.Data;
using FuelRoute.Infrastructure.Repositories;
using FuelRoute.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Controllers
builder.Services.AddControllers();

// OpenAPI / Swagger (new .NET 9 style)
builder.Services.AddOpenApi();

// DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("FuelRouteDb")); // or UseSqlServer(...) for real DB

// Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICarRepository, CarRepository>();

// Services
builder.Services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Map controllers for all environments
app.MapControllers();

app.Run();
