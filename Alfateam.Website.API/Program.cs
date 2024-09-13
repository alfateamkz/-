
using Alfateam.DB;
using Alfateam.Gateways;
using Alfateam.Gateways.Abstractions;
using Alfateam.Website.API.Filters;
using Alfateam.Website.API.Jobs;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
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

            // Add services to the container.
            builder.Services.AddDbContext<WebsiteDBContext>(options =>
            {
                options.UseMySql(new MySqlServerVersion(new Version(8, 0, 11)), o =>
                {
                    o.EnableRetryOnFailure();
                    o.EnableStringComparisonTranslations();
                });
            });

            builder.Services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo { Title = "Эта апишка для сайта и админки", Version = "V1" });



                //config.SchemaFilter<EnumSchemaFilter>();
                config.OperationFilter<SwaggerHeadersFilter>();
            });

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
            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
               
            //}

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            //new StaticFilesJob().Start();

            app.Run();
        }
    }
}