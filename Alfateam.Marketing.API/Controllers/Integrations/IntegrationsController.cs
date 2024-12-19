using Alfateam.Core;
using Alfateam.Core.Exceptions;
using Alfateam.Marketing.API.Abstractions;
using Alfateam.Marketing.API.Models;
using Alfateam.Marketing.API.Models.DTO.Abstractions.Integrations;
using Alfateam.Marketing.API.Models.DTO.MobileApps;
using Alfateam.Marketing.Models.Abstractions.Integrations;
using Alfateam.Marketing.Models.MobileApps;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Marketing.API.Controllers.Integrations
{
    public class IntegrationsController : AbsController
    {
        public IntegrationsController(ControllerParams @params) : base(@params)
        {
        }

        #region Общие интеграции

        [HttpGet, Route("GetIntegrations")]
        public async Task<ItemsWithTotalCount<IntegrationDTO>> GetIntegrations(SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<Integration, IntegrationDTO>(GetAvailableIntegrations(), filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    return entity.ToString().Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return true;
            });
        }

        [HttpGet, Route("GetIntegration")]
        public async Task<IntegrationDTO> GetIntegration(int id)
        {
            return (IntegrationDTO)DBService.TryGetOne(GetAvailableIntegrations(), id, new IntegrationDTO());
        }





        [HttpPost, Route("CreateIntegration")]
        public async Task<IntegrationDTO> CreateIntegration(IntegrationDTO model)
        {
            if(model is MobileAppIntegrationDTO || model is WebsiteIntegrationDTO)
            {
                throw new Exception400("Сюда можно добавлять только общие интеграции. Интеграции для сайтов или мобильных приложений добавляются в другом разделе");
            }

            return (IntegrationDTO)DBService.TryCreateEntity(DB.Integrations, model, callback: (entity) =>
            {
                entity.BusinessCompanyId = (int)this.CompanyId;
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление общей интеграции", $"Добавлена общая интеграция - {entity.ToString()}");
            });
        }

        [HttpPut, Route("UpdateIntegration")]
        public async Task<IntegrationDTO> UpdateIntegration(IntegrationDTO model)
        {
            if (model is MobileAppIntegrationDTO || model is WebsiteIntegrationDTO)
            {
                throw new Exception400("Сюда можно добавлять только общие интеграции. Интеграции для сайтов или мобильных приложений добавляются в другом разделе");
            }

            var item = GetAvailableIntegrations().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (IntegrationDTO)DBService.TryUpdateEntity(DB.Integrations, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование общей интеграции", $"Отредактирована общая интеграция с id={item.Id} - {item.ToString()}");
            });
        }




        [HttpDelete, Route("DeleteIntegration")]
        public async Task DeleteIntegration(int id)
        {
            var item = GetAvailableIntegrations().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(DB.Integrations, item);

            this.AddHistoryAction("Удаление общей интеграции", $"Удалена общая интеграция {item.ToString()} с id={id}");
        }


        #endregion






        #region Private methods
        private IEnumerable<Integration> GetAvailableIntegrations()
        {
            return DB.Integrations.Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
        }

        #endregion
    }
}
