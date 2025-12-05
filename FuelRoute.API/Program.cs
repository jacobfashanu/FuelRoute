using FuelRoute.Core.Interfaces;
using FuelRoute.Infrastructure;
using FuelRoute.Infrastructure.Data;
using FuelRoute.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// OpenAPI / Swagger
builder.Services.AddOpenApi();

// DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseInMemoryDatabase("FuelRouteDb");
});

// Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
// builder.Services.AddScoped<ICarRepository, CarRepository>();

// Services
builder.Services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();

// Configure HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapControllers();

app.Run();
