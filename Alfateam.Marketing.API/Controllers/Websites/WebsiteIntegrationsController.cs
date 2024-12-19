using Alfateam.Core;
using Alfateam.Core.Exceptions;
using Alfateam.Marketing.API.Abstractions;
using Alfateam.Marketing.API.Models;
using Alfateam.Marketing.API.Models.DTO.Abstractions.Integrations;
using Alfateam.Marketing.API.Models.DTO.Websites;
using Alfateam.Marketing.API.Models.SearchFilters.Websites;
using Alfateam.Marketing.Models.Abstractions.Integrations;
using Alfateam.Marketing.Models.Websites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebsiteModel = Alfateam.Marketing.Models.Websites.Website;

namespace Alfateam.Marketing.API.Controllers.Websites
{
    public class WebsiteIntegrationsController : AbsController
    {
        public WebsiteIntegrationsController(ControllerParams @params) : base(@params)
        {
        }

        #region Интеграции сторонних сервисов\метрик для сайтов

        [HttpGet, Route("GetWebsiteIntegrations")]
        public async Task<ItemsWithTotalCount<WebsiteIntegrationDTO>> GetWebsiteIntegrations(WebsiteIntegrationsSearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<Integration, WebsiteIntegrationDTO>(GetIntegrations(filter.WebsiteId), filter.Offset, filter.Count);
        }

        [HttpGet, Route("GetWebsiteIntegration")]
        public async Task<WebsiteIntegrationDTO> GetWebsiteIntegration(int websiteId, int integrationId)
        {
            return (WebsiteIntegrationDTO)DBService.TryGetOne(GetIntegrations(websiteId), integrationId, new WebsiteIntegrationDTO());
        }




        [HttpPost, Route("CreateWebsiteIntegration")]
        public async Task<WebsiteIntegrationDTO> CreateWebsiteIntegration(WebsiteIntegrationDTO model)
        {
            return (WebsiteIntegrationDTO)DBService.TryCreateEntity(DB.Integrations, model, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление интеграции для сайта", $"Добавлена интеграция для сайта - {entity.ToString()}");
            });
        }

        [HttpPut, Route("UpdateWebsiteIntegration")]
        public async Task<WebsiteIntegrationDTO> UpdateWebsiteIntegration(int websiteId, WebsiteIntegrationDTO model)
        {
            var item = GetIntegrations(websiteId).FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (WebsiteIntegrationDTO)DBService.TryUpdateEntity(DB.Integrations, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование интеграции для сайта", $"Отредактирована интеграция для сайта с id={item.Id} - {item.ToString()}");
            });
        }



        [HttpDelete, Route("DeleteWebsiteIntegration")]
        public async Task DeleteWebsiteIntegration(int websiteId, int integrationId)
        {
            var item = GetIntegrations(websiteId).FirstOrDefault(o => o.Id == integrationId && !o.IsDeleted);
            DBService.TryDeleteEntity(DB.Integrations, item);

            this.AddHistoryAction("Удаление интеграции для сайта", $"Удалена интеграции для сайта с id={integrationId} - {item.ToString()}");
        }




        #endregion







        #region Private methods

        private IEnumerable<WebsiteModel> GetAvailableWebsites()
        {
            return DB.Websites.Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
        }
        private IEnumerable<WebsiteIntegration> GetIntegrations(int websiteId)
        {
            var website = DB.Websites.Include(o => o.Integrations)
                                     .FirstOrDefault(o => o.Id == websiteId && o.BusinessCompanyId == this.CompanyId);
            if(website is null)
            {
                throw new Exception404("Сущность с данным id не найдена");
            }

            return website.Integrations.Where(o => !o.IsDeleted);
        }

        #endregion
    }
}
