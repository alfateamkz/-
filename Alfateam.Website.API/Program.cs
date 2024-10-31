
using Alfateam.Core.Filters.Swagger;
using Alfateam.Core.Forms;
using Alfateam.DB;
using Alfateam.Gateways;
using Alfateam.Gateways.Abstractions;
using Alfateam.Website.API.Filters;
using Alfateam.Website.API.Jobs;
using Alfateam.Website.API.Models;
using Alfateam.Website.API.Services.General;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Threading.RateLimiting;

namespace Alfateam.Website.API
{

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors();


            // Add services to the container.

            builder.Services.AddControllers(options =>
            {
                options.ModelBinderProviders.Insert(0, new FormDataJsonBinderProvider());
            })
            .AddNewtonsoftJson()
            .ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
                options.SuppressMapClientErrors = true;
            }); 

            builder.Services.AddHttpContextAccessor();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

      



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
            builder.Services.AddTransient<DBService>();
            builder.Services.AddTransient<FilesService>();
            builder.Services.AddTransient<ControllerParams>();

            builder.Services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Эта апишка для сайта и админки",
                    Description = "Есть сущность Content. В ней есть ContentItems. Они есть нескольких типов: </br></br>" +
                    "TextContentItem с полем Content. Сюда вставляется HTML контент из BBCode </br>" +
                    "ImageContentItem - поля ImgPath(путь к картинке), Title и Description </br>" +
                    "ImageSliderContentItem - поля Title, Description и Images(объекты ImageContentItem) </br>" +
                    "VideoContentItem - поля VideoPath, Title, Description </br>" +
                    "AudioContentItem - поля AudioPath, Title, Description </br></br>" +
                    "" +
                    "Во всех ContentItem имеется свойств Guid и Discriminator. Discriminator служит для указания типа, Guid для идентификации </br>" +
                    "Guid задается с фронта. Для всех файлов контента(картинки, аудио, видео) при загрузки ставится Guid, по нему будет заливаться файл  </br>" +
                    "При апдейте, если изменили файл, то меняем Guid. Если не меняли файл, то и не надо </br>" +
                    "" +
                    "</br></br></br>" +
                    "Любой ответ api оборачивается в следующую модель</br>" +
                    "{  </br>" +
                    "&emsp;\"success\": false,</br>" +
                    "&emsp;\"error\": \"Сущность с данным id не найдена\",</br>" +
                    "&emsp;\"code\": 404,</br>" +
                    "&emsp;\"data\": null</br>" +
                    "}</br></br></br>" +
                    "" +
                    "" +
                    "Сущность промокода. Есть нескольких типов</br></br>" +
                    "PricePromocode - содержит валюту и сумму скидки</br>" +
                    "PercentPromocodeDTO - содержит процент скидки</br>" +
                    "Во всех Promocode имеется свойств Discriminator. Discriminator служит для указания типа </br>" +
                    "</br></br></br>" +
                    "" +
                    "" +
                    "" +
                    "Сущность модификатора товара (ProductModifier)</br>" +
                    "У него есть некоторые поля Type(Color,Combobox,CheckboxOrRadio), IsRequired и AllowMultipleSelection и Options(ProductModifierItem)</br>" +
                    "ProductModifierItem есть нескольких типов</br>" +
                    "ColorModifierItem - с полем ColorHex</br>" +
                    "SimpleModifierItem - со стандартными полями в абстрактной сущности, а именно (Title, Pricing(PricingMatrix), Discriminator(для указания типа), MainLanguageId",
                    Version = "V1", });
                config.EnableAnnotations();



                config.DocumentFilter<DTODocumentFilter>();
                config.SchemaFilter<EnumSchemaFilter>();
                config.SchemaFilter<DTOSchemaFilter>();
                config.OperationFilter<SwaggerHeadersFilter>();
                config.OperationFilter<SwaggerMethodsFilter>();
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
            app.UseCors(options =>
                         options.AllowAnyOrigin()
                         .AllowAnyHeader()
                         .AllowAnyMethod());
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(app.Environment.ContentRootPath, "uploads")),
                RequestPath = "/uploads"
            });
            app.UseExceptionHandler("/error");

            //app.UseRouting();

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