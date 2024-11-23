
using Alfateam.Core.Filters.Swagger;
using Alfateam.Core.Services;
using Alfateam.DB;
using Alfateam.Gateways.Abstractions;
using Alfateam.Gateways;
using Alfateam.Sales.API.Filters;
using Alfateam.Sales.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Alfateam.DB.ServicesDBs;

namespace Alfateam.Sales.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddHttpContextAccessor();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddTransient<IMailGateway, MailGateway>();
            builder.Services.AddTransient<ISMSGateway, SMSGateway>();


            // Add services to the container.
            builder.Services.AddDbContext<DbContext, SalesDbContext>(options =>
            {
                options.UseMySql(new MySqlServerVersion(new Version(8, 0, 11)), o =>
                {
                    o.EnableRetryOnFailure();
                    o.EnableStringComparisonTranslations();
                });
            });
            builder.Services.AddDbContext<DbContext, IDDbContext>(options =>
            {
                options.UseMySql(new MySqlServerVersion(new Version(8, 0, 11)), o =>
                {
                    o.EnableRetryOnFailure();
                    o.EnableStringComparisonTranslations();
                });
            });
            builder.Services.AddDbContext<DbContext, CurrencyRatesDbContext>(options =>
            {
                options.UseMySql(new MySqlServerVersion(new Version(8, 0, 11)), o =>
                {
                    o.EnableRetryOnFailure();
                    o.EnableStringComparisonTranslations();
                });
            });


            builder.Services.AddTransient<AbsDBService>();
            builder.Services.AddTransient<AbsFilesService>();
            builder.Services.AddTransient<ControllerParams>();



            builder.Services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Это API для Alfateam - продажи",
                    Description = "Здесь все эндпоинты для самого Alfateam продажи - пользовательской части"
                });
                config.DocumentFilter<DTODocumentFilter>();
                config.SchemaFilter<EnumSchemaFilter>();
                config.SchemaFilter<DTOSchemaFilter>();
                config.OperationFilter<SwaggerHeadersFilter>();
                config.OperationFilter<SwaggerMethodsFilter>();
            });
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI();


            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
