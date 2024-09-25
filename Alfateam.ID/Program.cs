
using Alfateam.DB;
using Alfateam.Gateways.Abstractions;
using Alfateam.Gateways;
using Microsoft.EntityFrameworkCore;
using Alfateam.ID.Models;
using Alfateam.Core.Services;
using Alfateam.Core.Filters.Swagger;
using Alfateam.ID.API.Filters;
using Microsoft.OpenApi.Models;
using Alfateam.CRM2_0.Models.General.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Server.IISIntegration;

namespace Alfateam.ID
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle



            builder.Services.AddHttpContextAccessor();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();



            builder.Services.AddTransient<IMailGateway, MailGateway>();
            builder.Services.AddTransient<ISMSGateway, SMSGateway>();

            // Add services to the container.
            builder.Services.AddDbContext<DbContext,IDDbContext>(options =>
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
                    Title = "Это API для Alfateam ID",
                    Description = "Здесь все эндпоинты для самого ЛК Alfateam ID и для проброса авторизации через Alfateam ID"
                });
                config.SchemaFilter<EnumSchemaFilter>();
                config.OperationFilter<SwaggerHeadersFilter>();
            });

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
