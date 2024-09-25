
using Alfateam.Core.Services;
using Alfateam.DB;
using Alfateam.Gateways.Abstractions;
using Alfateam.Gateways;
using Microsoft.EntityFrameworkCore;
using Alfateam.EDM.API.Models;

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

            // Add services to the container.
            builder.Services.AddDbContext<EDMDbContext>(options =>
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
