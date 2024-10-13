using Alfateam.Core.Attributes.DTO;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Core.Filters.Swagger
{
    public class DTOSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (schema?.Properties == null)
            {
                return;
            }

            var properties = context.Type.GetProperties();

            foreach (var reflectionProp in properties)
            {
                var swaggerProp = schema.Properties.SingleOrDefault(o => string.Equals(o.Key, reflectionProp.Name, StringComparison.OrdinalIgnoreCase)).Value;



                SetDTOParamDescriptionRecursively(reflectionProp, swaggerProp);
            }
        }

        private void SetDTOParamDescriptionRecursively(PropertyInfo reflectionProp, OpenApiSchema swaggerProp)
        {
            SetDTOParamDescription(reflectionProp, swaggerProp);

            foreach (var childReflProp in reflectionProp.PropertyType.GetProperties())
            {  
                if(swaggerProp != null)
                {
                    var childSwaggerProp = swaggerProp.Properties.SingleOrDefault(o => string.Equals(o.Key, reflectionProp.Name, StringComparison.OrdinalIgnoreCase)).Value;
                    if(childSwaggerProp != null)
                    {
                        SetDTOParamDescription(childReflProp, childSwaggerProp);
                    }
                }
            }
        }

        private void SetDTOParamDescription(PropertyInfo reflectionProp, OpenApiSchema swaggerProp)
        {
            if (reflectionProp.GetCustomAttributes().Any(o => o is ForClientOnly)
                    && swaggerProp != null)
            {
                swaggerProp.Description = "Только для чтения";
            }

            if (reflectionProp.GetCustomAttributes().Any(o => o is HiddenFromClient)
              && swaggerProp != null)
            {
                swaggerProp.Description = "На клиенте не используется";
            }

            if (reflectionProp.GetCustomAttributes().Any(o => o is DTOFieldFor)
             && swaggerProp != null)
            {
                var fieldFor = reflectionProp.GetCustomAttributes().FirstOrDefault(o => o is DTOFieldFor) as DTOFieldFor;

                if (fieldFor.For == DTOFieldForType.UpdateOnly)
                {
                    swaggerProp.Description = "Используется только при редактировании";
                }
                else if (fieldFor.For == DTOFieldForType.CreationOnly)
                {
                    swaggerProp.Description = "Используется только при создании";
                }
            }


        }
    }
}
