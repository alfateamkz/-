using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Alfateam.Sales.API.Filters
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
                Description = "Сессия авторизованного пользователя Alfateam ID",
                Required = false
            });
        }
    }
}
