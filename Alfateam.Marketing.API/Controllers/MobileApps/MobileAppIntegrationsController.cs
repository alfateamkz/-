using Alfateam.Core.Exceptions;
using Alfateam.Core;
using Alfateam.Marketing.API.Abstractions;
using Alfateam.Marketing.API.Models;
using Alfateam.Marketing.API.Models.DTO.Abstractions.Integrations;
using Alfateam.Marketing.API.Models.SearchFilters.MobileApps;
using Alfateam.Marketing.Models.Abstractions.Integrations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Alfateam.Marketing.Models.MobileApps;

namespace Alfateam.Marketing.API.Controllers.MobileApps
{
    public class MobileAppIntegrationsController : AbsController
    {
        public MobileAppIntegrationsController(ControllerParams @params) : base(@params)
        {
        }

        #region Интеграции сторонних сервисов\метрик для мобильных приложений

        [HttpGet, Route("GetMobileAppIntegrations")]
        public async Task<ItemsWithTotalCount<MobileAppIntegrationDTO>> GetMobileAppIntegrations(MobileAppIntegrationsSearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<Integration, MobileAppIntegrationDTO>(GetIntegrations(filter.MobileAppId), filter.Offset, filter.Count);
        }

        [HttpGet, Route("GetMobileAppIntegration")]
        public async Task<MobileAppIntegrationDTO> GetMobileAppIntegration(int MobileAppId, int integrationId)
        {
            return (MobileAppIntegrationDTO)DBService.TryGetOne(GetIntegrations(MobileAppId), integrationId, new MobileAppIntegrationDTO());
        }




        [HttpPost, Route("CreateMobileAppIntegration")]
        public async Task<MobileAppIntegrationDTO> CreateMobileAppIntegration(MobileAppIntegrationDTO model)
        {
            return (MobileAppIntegrationDTO)DBService.TryCreateEntity(DB.Integrations, model, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление интеграции для мобильного приложения", $"Добавлена интеграция для мобильного приложения - {entity.ToString()}");
            });
        }

        [HttpPut, Route("UpdateMobileAppIntegration")]
        public async Task<MobileAppIntegrationDTO> UpdateMobileAppIntegration(int MobileAppId, MobileAppIntegrationDTO model)
        {
            var item = GetIntegrations(MobileAppId).FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (MobileAppIntegrationDTO)DBService.TryUpdateEntity(DB.Integrations, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование интеграции для мобильного приложения", $"Отредактирована интеграция для мобильного приложения с id={item.Id} - {item.ToString()}");
            });
        }



        [HttpDelete, Route("DeleteMobileAppIntegration")]
        public async Task DeleteMobileAppIntegration(int MobileAppId, int integrationId)
        {
            var item = GetIntegrations(MobileAppId).FirstOrDefault(o => o.Id == integrationId && !o.IsDeleted);
            DBService.TryDeleteEntity(DB.Integrations, item);

            this.AddHistoryAction("Удаление интеграции для мобильного приложения", $"Удалена интеграция для мобильного приложения с id={integrationId} - {item.ToString()}");
        }




        #endregion









        #region Private methods

        private IEnumerable<MobileApp> GetAvailableMobileApps()
        {
            return DB.MobileApps.Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
        }
        private IEnumerable<MobileAppIntegration> GetIntegrations(int mobileAppId)
        {
            var MobileApp = DB.MobileApps.Include(o => o.Integrations)
                                     .FirstOrDefault(o => o.Id == mobileAppId && o.BusinessCompanyId == this.CompanyId);
            if (MobileApp is null)
            {
                throw new Exception404("Сущность с данным id не найдена");
            }

            return MobileApp.Integrations.Where(o => !o.IsDeleted);
        }

        #endregion
    }
}
