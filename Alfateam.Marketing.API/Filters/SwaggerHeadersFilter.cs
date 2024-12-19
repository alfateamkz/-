using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Alfateam.Marketing.API.Filters
{
    public class SwaggerHeadersFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();




            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "API_KEY",
                In = ParameterLocation.Header,
                Description = "Ключ к API Alfateam CRM - маркетинг",
                Required = false
            });
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "AlfateamSessionID",
                In = ParameterLocation.Header,
                Description = "Сессия авторизованного пользователя Alfateam ID",
                Required = false
            });
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "Domain",
                In = ParameterLocation.Header,
                Description = "Домен бизнеса",
                Required = false
            });
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "CompanyId",
                In = ParameterLocation.Header,
                Description = "Идентификатор компании бизнеса",
                Required = false
            });
        }
    }
}
