using Alfateam.Core.Attributes.DTO;
using Alfateam.Core.Enums;
using Alfateam.Core.Helpers;
using Alfateam.Website.API.Abstractions;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Core.Filters.Swagger
{
    public class DTODocumentFilter : IDocumentFilter
    {
        private const string BASE_URL = "/"; // You might need to change this

        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {

           

            foreach (var apiDesc in context.ApiDescriptions)
            {
               
                var apiOperation = FindCorrespondingOperationInDocument(swaggerDoc, apiDesc);

                if (apiDesc.HttpMethod == "GET")
                {
                    var responseType = apiDesc.SupportedResponseTypes.FirstOrDefault(o => o.StatusCode == 200);
                    if (responseType.ModelMetadata is DefaultModelMetadata modelMetadata)
                    {
                        if (modelMetadata.IsEnumerableType && DTOModelAbs.IsModelTypeOf(modelMetadata.ElementType, typeof(DTOModelAbs)))
                        {
                            apiOperation.Description += $"<p>Структура JSON</p><pre> {DTOJsonSerialization.SerializeSampleModel(modelMetadata.ElementType, GetHttpMethodEnum(apiDesc.HttpMethod))} </pre>";
                        }
                        else if (modelMetadata.ModelType != null && DTOModelAbs.IsModelTypeOf(modelMetadata.ModelType, typeof(DTOModelAbs)))
                        {
                            apiOperation.Description += $"<p>Структура JSON</p><pre> {DTOJsonSerialization.SerializeSampleModel(modelMetadata.ModelType, GetHttpMethodEnum(apiDesc.HttpMethod))} </pre>";
                        }
                        else if (modelMetadata.ModelType != null && modelMetadata.ModelType.Name.Contains("ItemsWithTotalCount"))
                        {
                            apiOperation.Description += $"<p>Структура JSON</p><pre> {DTOJsonSerialization.SerializeSampleModel(modelMetadata.ModelType, GetHttpMethodEnum(apiDesc.HttpMethod))} </pre>";
                        }
                    }              
                }
                else if (apiDesc.HttpMethod != "DELETE")
                {

                    if (apiDesc.ActionDescriptor is ControllerActionDescriptor controller)
                    {
                        var arguments = controller.MethodInfo.GetParameters();
                        var dtoParams = arguments.Where(o => DTOModelAbs.IsModelTypeOf(o.ParameterType, typeof(DTOModelAbs))).ToList();
                        if (!dtoParams.Any())
                        {
                            continue;
                        }
                        apiOperation.RequestBody.Description += $"<p>Структура JSON</p><pre> {DTOJsonSerialization.SerializeSampleModel(dtoParams[0].ParameterType, GetHttpMethodEnum(apiDesc.HttpMethod))} </pre>";
                    }
                }
            }
        }


        private static bool IsDTOParam(ApiParameterDescription parameter)
        {
            if (parameter.ModelMetadata is DefaultModelMetadata modelMetadata)
            {
                if(DTOModelAbs.IsModelTypeOf(modelMetadata.ModelType, typeof(DTOModelAbs)))
                {
                    return true;
                }     
            }
            return false;
        }
        private static string CreateDTOParamSampleJSON(ApiParameterDescription parameter, string method)
        {
            if (parameter.ModelMetadata is DefaultModelMetadata modelMetadata)
            {
                if (DTOModelAbs.IsModelTypeOf(modelMetadata.ModelType, typeof(DTOModelAbs)))
                {
                    var gayson = DTOJsonSerialization.SerializeSampleModel(modelMetadata.ModelType, GetHttpMethodEnum(method)); 
                    return gayson;
                }
            }
            return "";
        }

        private OpenApiOperation FindCorrespondingOperationInDocument(OpenApiDocument swaggerDoc, ApiDescription apiDesc)
        {
            string pathUrl = BASE_URL + apiDesc.RelativePath;
            OperationType httpMethod = GetOperationTypeFromHttpMethod(apiDesc.HttpMethod!);

            OpenApiPathItem apiPath = swaggerDoc.Paths[pathUrl];
            return apiPath.Operations[httpMethod];
        }

        private static OperationType GetOperationTypeFromHttpMethod(string httpMethod)
        {
            httpMethod = httpMethod.ToLower();
            httpMethod = string.Concat(httpMethod[0].ToString().ToUpper(), httpMethod.AsSpan(1));
            return Enum.Parse<OperationType>(httpMethod);
        }

        private static DTOJsonSerializationType GetHttpMethodEnum(string method)
        {
            DTOJsonSerializationType methodType = DTOJsonSerializationType.GET;
            switch (method)
            {
                case "GET":
                    methodType = DTOJsonSerializationType.GET;
                    break;
                case "POST":
                    methodType = DTOJsonSerializationType.POST;
                    break;
                case "PUT":
                    methodType = DTOJsonSerializationType.PUT;
                    break;
            }

            return methodType;
        }
    }
}
