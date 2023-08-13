
using Alfateam.Gateways;
using Alfateam.Gateways.Abstractions;
using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

namespace Alfateam.Website.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddNewtonsoftJson();
         
            
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddTransient<IMailGateway, MailGateway>();

            //builder.Services.AddRateLimiter(_ => _
            //.AddFixedWindowLimiter(policyName: "fixed", options =>
            //{
            //    options.PermitLimit = 4;
            //    options.Window = TimeSpan.FromSeconds(12);
            //    options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
            //    options.QueueLimit = 2;
            // }));


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