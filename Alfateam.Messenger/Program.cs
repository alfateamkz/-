
using Alfateam.Core.Filters.Swagger;
using Alfateam.Core.Services;
using Alfateam.DB;
using Alfateam.Gateways.Abstractions;
using Alfateam.Gateways;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Alfateam.Messenger.API.Models;
using Alfateam.Messenger.API.Filters;
using Alfateam.Messenger.API.Controllers.Messenger;
using Alfateam.Messenger.API.Services;

namespace Alfateam.Messenger
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
            builder.Services.AddSignalR();




            builder.Services.AddTransient<IMailGateway, MailGateway>();
            builder.Services.AddTransient<ISMSGateway, SMSGateway>();

            // Add services to the container.
            builder.Services.AddDbContext<MessengerDbContext>(options =>
            {
                options.UseMySql(new MySqlServerVersion(new Version(8, 0, 11)), o =>
                {
                    o.EnableRetryOnFailure();
                    o.EnableStringComparisonTranslations();
                });
            });
            // Add services to the container.
            builder.Services.AddDbContext<IDDbContext>(options =>
            {
                options.UseMySql(new MySqlServerVersion(new Version(8, 0, 11)), o =>
                {
                    o.EnableRetryOnFailure();
                    o.EnableStringComparisonTranslations();
                });
            });
            builder.Services.AddTransient<AbsDBService>(x => new AbsDBService(x.GetRequiredService<MessengerDbContext>()));
            builder.Services.AddTransient<AbsFilesService>();

            builder.Services.AddTransient<ChatMiscService>();

            builder.Services.AddTransient<ControllerParams>();




            builder.Services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Это API для Alfateam мессенджера",
                    Description = "Здесь все эндпоинты для Alfateam мессенджера"
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
            app.MapHub<MessengerWebSocketHub>("/MessengerWebSocketHub");

            app.Run();
        }
    }
}
