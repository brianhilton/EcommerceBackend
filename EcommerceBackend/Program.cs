using EcommerceBackend.Data.Context;
using EcommerceBackend.Data.Models;
using EcommerceBackend.Data.Repository;
using EcommerceBackend.Logic.Interfaces;
using EcommerceBackend.Logic.Services;
using Microsoft.EntityFrameworkCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var stringBuilder = new NpgsqlConnectionStringBuilder();

stringBuilder.Database = "postgres";
stringBuilder.Host = "localhost";
stringBuilder.Password = "password123";
stringBuilder.Port = 5432;
stringBuilder.Username = "postgres";


var con = stringBuilder.ConnectionString;

builder.Services
    .AddLogging()
    .AddDbContextFactory<DataContext>(opt => opt.UseNpgsql(stringBuilder.ConnectionString))
    .AddDbContext<DbContext, DataContext>(opt => opt.UseNpgsql(stringBuilder.ConnectionString))
    .AddScoped<IGenericRepository<User>, GenericRepository<User>>()
    .AddScoped<IGenericRepository<Product>, GenericRepository<Product>>()
    .AddScoped<IUserService, UserService>()
    .AddScoped<IProductService, ProductService>()
    .AddScoped<ITokenService, TokenService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseCors(builder => builder
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin()
);

app.UseAuthorization();

app.MapControllers();

app.Run();