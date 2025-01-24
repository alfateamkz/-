
using Alfateam.Core.Filters.Swagger;
using Alfateam.Gateways.Abstractions;
using Alfateam.Gateways;
using Microsoft.OpenApi.Models;
using Alfateam.Core.Services;
using Alfateam.DB.ServicesDBs;
using Alfateam.DB;
using Microsoft.EntityFrameworkCore;
using Alfateam.AdminPanelGeneral.API.Models;
using Alfateam.AdminPanelGeneral.API.Filters;
using Microsoft.Extensions.Options;

namespace Alfateam.AdminPanelGeneral
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddHttpContextAccessor();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(config =>
            {
                config.CustomSchemaIds(type => type.ToString());
                config.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Это API для Alfateam - админ. панель",
                    Description = "Здесь все эндпоинты для самой Alfateam админ. панели"
                });
                config.DocumentFilter<DTODocumentFilter>();
                config.SchemaFilter<EnumSchemaFilter>();
                config.SchemaFilter<DTOSchemaFilter>();
                config.OperationFilter<SwaggerHeadersFilter>();
                config.OperationFilter<SwaggerMethodsFilter>();
            });

            builder.Services.AddTransient<IMailGateway, MailGateway>();
            builder.Services.AddTransient<ISMSGateway, SMSGateway>();



            builder.Services.AddDbContext<AdmininstrationDbContext>(options =>
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



            builder.Services.AddDbContext<SalesDbContext>(options =>
            {
                options.UseMySql(new MySqlServerVersion(new Version(8, 0, 11)), o =>
                {
                    o.EnableRetryOnFailure();
                    o.EnableStringComparisonTranslations();
                });
            });
            builder.Services.AddDbContext<MarketingDbContext>(options =>
            {
                options.UseMySql(new MySqlServerVersion(new Version(8, 0, 11)), o =>
                {
                    o.EnableRetryOnFailure();
                    o.EnableStringComparisonTranslations();
                });
            });
            builder.Services.AddDbContext<TelephonyDbContext>(options =>
            {
                options.UseMySql(new MySqlServerVersion(new Version(8, 0, 11)), o =>
                {
                    o.EnableRetryOnFailure();
                    o.EnableStringComparisonTranslations();
                });
            });
            builder.Services.AddDbContext<MessengerDbContext>(options =>
            {
                options.UseMySql(new MySqlServerVersion(new Version(8, 0, 11)), o =>
                {
                    o.EnableRetryOnFailure();
                    o.EnableStringComparisonTranslations();
                });
            });
            builder.Services.AddDbContext<EDMDbContext>(options =>
            {
                options.UseMySql(new MySqlServerVersion(new Version(8, 0, 11)), o =>
                {
                    o.EnableRetryOnFailure();
                    o.EnableStringComparisonTranslations();
                });
            });




            builder.Services.AddTransient<AbsDBService>(x => new AbsDBService(x.GetRequiredService<AdmininstrationDbContext>()));
            builder.Services.AddTransient<AbsFilesService>();
            builder.Services.AddTransient<ControllerParams>();


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
