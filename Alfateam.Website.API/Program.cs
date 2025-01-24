
using Alfateam.Core.Filters.Swagger;
using Alfateam.Core.Forms;
using Alfateam.DB;
using Alfateam.Gateways;
using Alfateam.Gateways.Abstractions;
using Alfateam.Website.API.Filters;
using Alfateam.Website.API.Jobs;
using Alfateam.Website.API.Models;
using Alfateam.Website.API.Services.General;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
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


            builder.Services.Configure<IISServerOptions>(options =>
            {
                options.MaxRequestBodySize = int.MaxValue;
            });

            builder.Services.Configure<KestrelServerOptions>(options =>
            {
                options.Limits.MaxRequestBodySize = int.MaxValue;
            });

            builder.Services.Configure<FormOptions>(x =>
            {
                x.ValueLengthLimit = int.MaxValue;
                x.MultipartBodyLengthLimit = int.MaxValue; // if don't set default value is: 128 MB
                x.MultipartHeadersLengthLimit = int.MaxValue;
            });


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
                    Title = "��� ������ ��� ����� � �������",
                    Description = "���� �������� Content. � ��� ���� ContentItems. ��� ���� ���������� �����: </br></br>" +
                    "TextContentItem � ����� Content. ���� ����������� HTML ������� �� BBCode </br>" +
                    "ImageContentItem - ���� ImgPath(���� � ��������), Title � Description </br>" +
                    "ImageSliderContentItem - ���� Title, Description � Images(������� ImageContentItem) </br>" +
                    "VideoContentItem - ���� VideoPath, Title, Description </br>" +
                    "AudioContentItem - ���� AudioPath, Title, Description </br></br>" +
                    "" +
                    "�� ���� ContentItem ������� ������� Guid � Discriminator. Discriminator ������ ��� �������� ����, Guid ��� ������������� </br>" +
                    "Guid �������� � ������. ��� ���� ������ ��������(��������, �����, �����) ��� �������� �������� Guid, �� ���� ����� ���������� ����  </br>" +
                    "��� �������, ���� �������� ����, �� ������ Guid. ���� �� ������ ����, �� � �� ���� </br>" +
                    "" +
                    "</br></br></br>" +
                    "����� ����� api ������������� � ��������� ������</br>" +
                    "{  </br>" +
                    "&emsp;\"success\": false,</br>" +
                    "&emsp;\"error\": \"�������� � ������ id �� �������\",</br>" +
                    "&emsp;\"code\": 404,</br>" +
                    "&emsp;\"data\": null</br>" +
                    "}</br></br></br>" +
                    "" +
                    "" +
                    "�������� ���������. ���� ���������� �����</br></br>" +
                    "PricePromocode - �������� ������ � ����� ������</br>" +
                    "PercentPromocodeDTO - �������� ������� ������</br>" +
                    "�� ���� Promocode ������� ������� Discriminator. Discriminator ������ ��� �������� ���� </br>" +
                    "</br></br></br>" +
                    "" +
                    "" +
                    "" +
                    "�������� ������������ ������ (ProductModifier)</br>" +
                    "� ���� ���� ��������� ���� Type(Color,Combobox,CheckboxOrRadio), IsRequired � AllowMultipleSelection � Options(ProductModifierItem)</br>" +
                    "ProductModifierItem ���� ���������� �����</br>" +
                    "ColorModifierItem - � ����� ColorHex</br>" +
                    "SimpleModifierItem - �� ������������ ������ � ����������� ��������, � ������ (Title, Pricing(PricingMatrix), Discriminator(��� �������� ����), MainLanguageId",
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

            new StaticFilesJob().Start();

            app.Run();
        }
    }
}