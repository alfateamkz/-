using Alfateam.Core;
using Alfateam.Core.Exceptions;
using Alfateam.Messenger.API.Abstractions;
using Alfateam.Messenger.API.Models;
using Alfateam.Messenger.Models.DTO.Integrations.ExtMessenger;
using Alfateam.Messenger.Models.Integrations.ExtMessenger;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.Messenger.API.Controllers.Integrations
{
    public class ExtMessengerIntegrationsController : AbsController
    {
        public ExtMessengerIntegrationsController(ControllerParams @params) : base(@params)
        {
        }

        #region Внешние интеграции мессенджера

        [HttpGet, Route("GetIntegrations")]
        public async Task<ItemsWithTotalCount<ExtMessengerIntegrationDTO>> GetIntegrations(SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<ExtMessengerIntegration, ExtMessengerIntegrationDTO>(GetAvailableIntegrations(), filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    return entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return true;
            });
        }

        [HttpGet, Route("GetIntegration")]
        public async Task<ExtMessengerIntegrationDTO> GetIntegration(int id)
        {
            return (ExtMessengerIntegrationDTO)DBService.TryGetOne(GetAvailableIntegrations(), id, new ExtMessengerIntegrationDTO());
        }


        [HttpPost, Route("CreateIntegration")]
        public async Task<ExtMessengerIntegrationDTO> CreateIntegration(ExtMessengerIntegrationDTO model)
        {
            return (ExtMessengerIntegrationDTO)DBService.TryCreateEntity(DB.ExtMessengerIntegrations, model, callback: (entity) =>
            {
                entity.BusinessId = (int)this.BusinessId;
            });
        }

        [HttpPut, Route("UpdateIntegration")]
        public async Task<ExtMessengerIntegrationDTO> UpdateIntegration(ExtMessengerIntegrationDTO model)
        {
            var item = DBService.TryGetOne(GetAvailableIntegrations(), model.Id);
            return (ExtMessengerIntegrationDTO)DBService.TryUpdateEntity(DB.ExtMessengerIntegrations, model, item);
        }

        [HttpPut, Route("RefreshIntegrationSecretKey")]
        public async Task<string> RefreshIntegrationSecretKey(int id)
        {
            var item = DBService.TryGetOne(GetAvailableIntegrations(), id);
            item.SecretToken = System.Guid.NewGuid().ToString();

            DBService.UpdateEntity(DB.ExtMessengerIntegrations, item);
            return item.SecretToken;
        }

        [HttpDelete, Route("DeleteIntegration")]
        public async Task DeleteIntegration(int id)
        {
            var item = DBService.TryGetOne(GetAvailableIntegrations(), id);
            if (item.PaidBefore != null && item.PaidBefore > DateTime.UtcNow)
            {
                throw new Exception403($"Нельзя удалить интеграцию, так как она оплачена до {item.PaidBefore.Value} по UTC\r\n" +
                                       $"Вы можете деактивировать интеграцию в настройках");
            }

            DBService.TryDeleteEntity(DB.ExtMessengerIntegrations, item);
        }

        #endregion








        #region Private methods
        private IEnumerable<ExtMessengerIntegration> GetAvailableIntegrations()
        {
            return DB.ExtMessengerIntegrations.Where(o => !o.IsDeleted && o.BusinessId == this.BusinessId);
        }

        #endregion
    }
}
