using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Alfateam.EDM.API.Filters
{
    public class SwaggerHeadersFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();


            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "AlfateamSessionID",
                In = ParameterLocation.Header,
                Description = "Сессия пользователя Alfateam ID (если авторизованы)",
                Required = false
            });
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "Domain",
                In = ParameterLocation.Header,
                Description = "Поддомен бизнеса",
                Required = false
            });
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "EDMSubjectId",
                In = ParameterLocation.Header,
                Description = "Id субъекта ЭДО",
                Required = false
            });
        }
    }
}
