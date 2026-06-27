using Microsoft.EntityFrameworkCore;
using Progredi.DataAccess;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(
    options => {
        options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
    });

var app = builder.Build();

// app.UseSwagger();
// app.UseSwaggerUI();
