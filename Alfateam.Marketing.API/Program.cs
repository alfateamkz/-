
using Alfateam.Core.Filters.Swagger;
using Alfateam.Core.Services;
using Alfateam.DB.ServicesDBs;
using Alfateam.DB;
using Alfateam.Gateways;
using Alfateam.Gateways.Abstractions;
using Alfateam.Marketing.API.HostedServices;
using Alfateam.Marketing.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Alfateam.Marketing.API.Filters;


namespace Alfateam.Marketing.API
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
            builder.Services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Это API для Alfateam - маркетинг",
                    Description = "Здесь все эндпоинты для самого Alfateam маркетинг - пользовательской части"
                });
                config.DocumentFilter<DTODocumentFilter>();
                config.SchemaFilter<EnumSchemaFilter>();
                config.SchemaFilter<DTOSchemaFilter>();
                config.OperationFilter<SwaggerHeadersFilter>();
                config.OperationFilter<SwaggerMethodsFilter>();
            });

            builder.Services.AddTransient<IMailGateway, MailGateway>();
            builder.Services.AddTransient<ISMSGateway, SMSGateway>();



            builder.Services.AddDbContext<MarketingDbContext>(options =>
            {
                options.UseMySql(new MySqlServerVersion(new Version(8, 0, 11)), o =>
                {
                    o.EnableRetryOnFailure();
                    o.EnableStringComparisonTranslations();
                });
            });

            builder.Services.AddDbContext<SalesDbContext>(options =>
            {
                options.UseMySql(new MySqlServerVersion(new Version(8, 0, 11)), o =>
                {
                    o.EnableRetryOnFailure();
                    o.EnableStringComparisonTranslations();
                });
            });
            builder.Services.AddDbContext<IDDbContext>(options =>
            {
                options.UseMySql(new MySqlServerVersion(new Version(8, 0, 11)), o =>
                {
                    o.EnableRetryOnFailure();
                    o.EnableStringComparisonTranslations();
                });
            });
            builder.Services.AddDbContext<CurrencyRatesDbContext>(options =>
            {
                options.UseMySql(new MySqlServerVersion(new Version(8, 0, 11)), o =>
                {
                    o.EnableRetryOnFailure();
                    o.EnableStringComparisonTranslations();
                });
            });

            builder.Services.AddTransient<AbsDBService>(x => new AbsDBService(x.GetRequiredService<MarketingDbContext>()));
            builder.Services.AddTransient<AbsFilesService>();
            builder.Services.AddTransient<ControllerParams>();



            builder.Services.AddHostedService<AutopostingHostedService>();
            builder.Services.AddHostedService<WebsiteOnlinePingHostedService>();


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
