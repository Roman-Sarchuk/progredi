using Microsoft.EntityFrameworkCore;
using Progredi.DataAccess;
using Progredi.Interfaces;
using Progredi.Services;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(
    options => {
        options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
    });

builder.Services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();

app.MapControllers();

app.Run();

// app.UseSwagger();
// app.UseSwaggerUI();
