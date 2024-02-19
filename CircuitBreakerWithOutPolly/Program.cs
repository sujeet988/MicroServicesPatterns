
using CircuitBreakerWithOutPolly;
using Microsoft.OpenApi.Models;

using Polly;
using Polly.CircuitBreaker;

namespace CircuitBreakerWithOutPolly
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddHttpClient<IJokeService, JokeService>();

            //Poly :

            builder.Services.AddHttpClient<IJokeService, JokeService>(client =>
                {
                    client.BaseAddress = new Uri("https://official-joke-api.appspot.com/random_joke");
                }).AddTransientHttpErrorPolicy(policy => policy.CircuitBreakerAsync(3, TimeSpan.FromMilliseconds(120000)));
            

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Circuit Breaker WithOut Polly", Version = "v1" });
            });
           

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