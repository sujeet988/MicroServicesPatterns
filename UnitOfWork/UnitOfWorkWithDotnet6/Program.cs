using UnitOfWorkWithDotnet6.Models;
using UnitOfWorkWithDotnet6.UOW;
using Microsoft.EntityFrameworkCore;
namespace UnitOfWorkWithDotnet6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //Configure the ConnectionString and DbContext Class
            builder.Services.AddDbContext<EFCoreDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("EFCoreDBConnection"));

            });
                //Registering the UnitOfWork
                builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


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

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}