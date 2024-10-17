
using Microsoft.EntityFrameworkCore;
using URLShortner.Models;
using URLShortner.Services;

namespace URLShortner
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<URLContext>(option =>
            {
                option.UseSqlServer("Server=DESKTOP-I7PU4G3;Database=URLShortner;Trusted_Connection=True;Encrypt=false");
            });
            builder.Services.AddScoped<URLService>();
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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
