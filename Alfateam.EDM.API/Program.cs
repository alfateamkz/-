
using Alfateam.Core.Services;
using Alfateam.DB;
using Alfateam.Gateways.Abstractions;
using Alfateam.Gateways;
using Microsoft.EntityFrameworkCore;
using Alfateam.EDM.API.Models;
using Alfateam.Core.Filters.Swagger;
using Microsoft.OpenApi.Models;
using Alfateam.EDM.API.Filters;
using Alfateam.EDM.API.Services;
using Alfateam.EDM.API.Jobs;
using Alfateam.DB.Services;
using Alfateam.DB.Services.Jobs;

namespace Alfateam.EDM.API
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



            builder.Services.AddTransient<IMailGateway, MailGateway>();
            builder.Services.AddTransient<ISMSGateway, SMSGateway>();



            builder.Services.AddDbContext<CertCenterDbContext>(options =>
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
            builder.Services.AddDbContext<IDDbContext>(options =>
            {
                options.UseMySql(new MySqlServerVersion(new Version(8, 0, 11)), o =>
                {
                    o.EnableRetryOnFailure();
                    o.EnableStringComparisonTranslations();
                });
            });
            builder.Services.AddTransient<AbsDBService>(x => new AbsDBService(x.GetRequiredService<EDMDbContext>()));
            builder.Services.AddTransient<AbsFilesService>();
            builder.Services.AddTransient<CertCenterVerificationService>();
            builder.Services.AddTransient<DocumentsService>();
            builder.Services.AddTransient<DocumentApprovalService>();
            builder.Services.AddTransient<UploadedFilesService>();
            builder.Services.AddTransient<ControllerParams>();


  

            builder.Services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Это API для Alfateam ЭДО",
                    Description = "Здесь все эндпоинты для Alfateam ЭДО"
                });
                config.SchemaFilter<EnumSchemaFilter>();
                config.SchemaFilter<DTOSchemaFilter>();
                config.OperationFilter<SwaggerHeadersFilter>();
                config.OperationFilter<SwaggerMethodsFilter>();
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            UnusedUploadedFilesJob.Start<EDMDbContext>();
            ApprovalRoutesJob.Start();

            app.Run();
        }
    }
}
