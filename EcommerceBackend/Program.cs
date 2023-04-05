using System.ComponentModel;
using EcommerceBackend.Logic.Interfaces;
using EcommerceBackend.Logic.Services;
using EcommerceBackend.Controllers;

namespace EcommerceBackend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //builder.Services.AddSingleton<IUserService>(new UserService(CreateContainer("users")));
            //builder.Services.AddSingleton<IStoreItemService>(new StoreItemController(CreateContainer("storeitems")));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

            }

            app.UseHttpsRedirection();
            app.UseCors(builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin()
            );
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }


    }
}