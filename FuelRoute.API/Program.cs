using System.Text;
using FuelRoute.Core.Interfaces;
using FuelRoute.Infrastructure;
using FuelRoute.Infrastructure.Data;
using FuelRoute.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add controllers
builder.Services.AddControllers();

// OpenAPI / minimal Swagger
builder.Services.AddOpenApi();

// DbContext registration (no provider configured – for demo/assignment)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    // Intentionally left without UseInMemoryDatabase / UseSqlServer
    // This is enough to demonstrate layering & DI for the assignment.
});

// JWT configuration
var jwtSection = builder.Configuration.GetSection("Jwt");
var jwtKey = Encoding.UTF8.GetBytes(jwtSection["Key"] ?? "DEMO_SECRET_KEY_CHANGE_ME");

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = jwtSection["Issuer"],
            ValidateAudience = true,
            ValidAudience = jwtSection["Audience"],
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(jwtKey),
            ValidateLifetime = true
        };
    });

// Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Services
builder.Services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();

// Pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
