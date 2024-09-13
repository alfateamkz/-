using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Alfateam.Website.API.Filters
{
    public class SwaggerHeadersFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "Sessid",
                In = ParameterLocation.Header,
                //Description = "string?",
                Required = false 
            });
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "CountryId",
                In = ParameterLocation.Header,
                //Description = "int?",
                Required = false
            });
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "CurrencyId",
                In = ParameterLocation.Header,
                //Description = "int?",
                Required = false
            });
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "LanguageId",
                In = ParameterLocation.Header,
                //Description = "int?",
                Required = false
            });
        }
    }
}
