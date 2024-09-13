using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Runtime.Serialization;

namespace Alfateam.Website.API.Filters
{
    public class EnumSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema model, SchemaFilterContext context)
        {
            if (context.Type.IsEnum)
            {
                model.Enum.Clear();


                var enumNames = Enum.GetNames(context.Type).ToList();
                foreach (string enumName in enumNames)
                {
                    System.Reflection.MemberInfo memberInfo = context.Type.GetMember(enumName).FirstOrDefault(m => m.DeclaringType == context.Type);

                    EnumMemberAttribute enumMemberAttribute = memberInfo == null
                     ? null
                     : memberInfo.GetCustomAttributes(typeof(EnumMemberAttribute), false).OfType<EnumMemberAttribute>().FirstOrDefault();

                   


                    string label = enumMemberAttribute == null || string.IsNullOrWhiteSpace(enumMemberAttribute.Value)
                     ? enumName
                     : enumMemberAttribute.Value;


                    Enum myEnum = (Enum)Enum.Parse(context.Type, enumName);

                    model.Enum.Add(new OpenApiString($"{Convert.ToInt32(myEnum)} - {label}"));
                }
            }
        }
    }
}
