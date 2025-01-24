using Alfateam.Core.Exceptions;
using Alfateam.TicketSystem.API.Abstractions;
using Alfateam.TicketSystem.Models.Integrations.API;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;

namespace Alfateam.TicketSystem.API.Filters
{
    public class AlfateamAPIKeyFilter : Attribute, IActionFilter
    {
        public const string FRONTEND_HOST = "ticketsalfateam.com";
        public void OnActionExecuted(ActionExecutedContext context)
        {
            var controller = context.Controller as AbsController;
            var apiKey = controller.DB.AlfateamAPIKeys.FirstOrDefault(o => o.Key == controller.API_KEY && !o.IsDeleted);

            if (!apiKey.IsDefault)
            {
                var entry = CreateRequestEntry(apiKey.Id, controller.HttpContext);
                controller.DBService.CreateEntity(controller.DB.AlfateamAPIRequestEntries, entry);
            }
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.Controller as AbsController;
            var apiKey = controller.DB.AlfateamAPIKeys.FirstOrDefault(o => o.Key == controller.API_KEY && !o.IsDeleted);

            if (apiKey == null)
            {
                throw new Exception404($"API ключ {controller.API_KEY} в системе не найден");
            }
            else if (apiKey.BusinessId != controller.BusinessId)
            {
                throw new Exception403($"API ключ {controller.API_KEY} не принадлежит домену {controller.Domain}");
            }

#if !DEBUG
            if(apiKey.IsDefault && context.HttpContext.Request.Host.Host != FRONTEND_HOST)
            {
                 throw new Exception403($"Ах ты какой хитрый! Данный API ключ нельзя использовать со сторонних источников. " +
                                        $"Приобретите ключ, чтобы можно было пользоваться API Alfateam");
            }

#endif

            if (!apiKey.IsDefault && (apiKey.PaidBefore == null || apiKey.PaidBefore < DateTime.UtcNow))
            {
                throw new Exception403($"Срок действия ключа закончился. Продлите ключ, чтобы можно было пользоваться API Alfateam");
            }
            else if (!apiKey.IsEnabled)
            {
                throw new Exception403($"API ключ деактивирован");
            }
        }






        private AlfateamAPIRequestEntry CreateRequestEntry(int apiKeyId, HttpContext httpContext)
        {
            return new AlfateamAPIRequestEntry
            {
                HTTPMethod = httpContext.Request.Method,
                URL = httpContext.Request.Path,
                AlfateamAPIKeyId = apiKeyId,
                UserAgent = httpContext.Request.Headers["User-Agent"],
                Headers = GetHeadersString(httpContext),
                IP = httpContext.Connection.RemoteIpAddress?.ToString(),
                Response = new StreamReader(httpContext.Response.Body).ReadToEnd(),
            };
        }
        private string GetHeadersString(HttpContext httpContext)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var header in httpContext.Request.Headers)
            {
                builder.AppendLine($"{header.Key}: {header.Value}");
            }

            return builder.ToString();
        }
    }
}
