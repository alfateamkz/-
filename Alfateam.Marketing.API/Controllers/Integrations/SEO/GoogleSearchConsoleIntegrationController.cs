using Alfateam.Marketing.API.Abstractions;
using Alfateam.Marketing.API.Models;
using Google.Apis.SearchConsole.v1.Data;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.Marketing.API.Controllers.Integrations.SEO
{
    public class GoogleSearchConsoleIntegrationController : AbsController
    {
        public GoogleSearchConsoleIntegrationController(ControllerParams @params) : base(@params)
        {
           
            //TODO: Получить Google OAuth и сделать эндпоинты по методам
        }

        [HttpGet, Route("Hui")]
        public async Task Hui()
        {
            try
            {
                var service = new Google.Apis.SearchConsole.v1.SearchConsoleService();
                var resource = new Google.Apis.SearchConsole.v1.SearchanalyticsResource(service);

                var request = resource.Query(new SearchAnalyticsQueryRequest
                {

                }, "https://youmi.ru");
                request.AccessToken = "AIzaSyBW4zk2wOVve0-ynNtxeCoWj451caH1_R4";

                var response = request.Execute();
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
