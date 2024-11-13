using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Core.Filters.Swagger
{
    public class SwaggerMethodsFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();


            if(operation.RequestBody != null)
            {
                
            }

            operation.Description += "<pre>";

            var methodParams = context.MethodInfo.GetParameters();
            if (methodParams.Length > 0)
            {
                operation.Description += "</br></br> <b>Параметры:</b>";

                foreach (var param in methodParams)
                {
                    operation.Description += $"</br> {param.Name} {param.ParameterType.Name}";

                    if (param.ParameterType.IsEnum)
                    {
                        operation.Description += " (enum, query param)";
                    }
                    else if (param.ParameterType.Name.EndsWith("DTO"))
                    {
                        operation.Description += " (DTO, request body or form)";
                    }
                    else if (param.ParameterType.Name.EndsWith("IEnumerable"))
                    {
                        operation.Description += " (array, request body or form)";
                    }
                    else
                    {
                        operation.Description += " (query param)";
                    }
                }

                operation.Description += "</br></br>";
            }

            operation.Description += "<b>Возвращаемый тип:</b> ";
            if (context.MethodInfo.ReturnType == typeof(void) || context.MethodInfo.ReturnType == typeof(Task))
            {
                operation.Description += "Ни хуя не возвращает, кроме обертки ответа и статуса";
            }
            else if(context.MethodInfo.ReturnType.Name.Contains("Task`1"))
            {
                var taskReturnType = context.MethodInfo.ReturnType.GenericTypeArguments[0];

                if (taskReturnType.Name.Contains("IEnumerable"))
                {
                    var arrayType = taskReturnType.GenericTypeArguments[0];
                    operation.Description += "Массив с "+ arrayType.Name;
                }
                else if (taskReturnType.Name.Contains("ItemsWithTotalCount"))
                {
                    var arrayType = taskReturnType.GenericTypeArguments[0];
                    operation.Description += "Список с " + arrayType.Name + " и кол-вом сущностей в БД";
                }
                else
                {
                    operation.Description += taskReturnType.Name;
                }              
            }
            else 
            {
                operation.Description += context.MethodInfo.ReturnType.ToString();
            }

            operation.Description += "</br></br>";
            operation.Description += "</pre>";
        }
    }
}
