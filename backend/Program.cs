using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using Progredi.DataAccess;
using Progredi.Interfaces;
using Progredi.Services;
using Progredi.Middleware;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(
    options => {
        options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
    });

builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddProblemDetails();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

var app = builder.Build();

app.UseExceptionHandler();

app.MapOpenApi();
app.MapScalarApiReference();

app.MapControllers();

app.Run();
