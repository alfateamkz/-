using Alfateam.Core.Exceptions;
using Alfateam.Marketing.Models.Abstractions.Integrations;
using Alfateam.Messenger.API.Abstractions;
using Alfateam.Messenger.API.Models;
using Alfateam.Messenger.Models.DTO.Integrations.ExtMessenger;
using Alfateam.Messenger.Models.Integrations.ExtMessenger;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.Messenger.API.Controllers.Public
{
    public class PublicExtMessengerIntegrationController : AbsController
    {
        public string IntegrationSecretKey => Request.Headers["IntegrationSecretKey"];
        public ExtMessengerIntegration Integration
        {
            get
            {
                var integration = DB.ExtMessengerIntegrations.FirstOrDefault(o => o.SecretToken == IntegrationSecretKey && !o.IsDeleted);
                if(integration == null)
                {
                    throw new Exception401("Интеграция не найдена");
                }
                return integration;
            }
        }

        public PublicExtMessengerIntegrationController(ControllerParams @params) : base(@params)
        {
        }

        #region Пользователи

        [HttpGet, Route("GetUser")]
        public async Task<ExtMessengerUserDTO> GetUser(string uniqueId)
        {
            var user = TryGetUser(this.Integration.Id, uniqueId);
            return (ExtMessengerUserDTO)new ExtMessengerUserDTO().CreateDTO(user);
        }

        [HttpPost, Route("CreateUser")]
        public async Task<ExtMessengerUserDTO> CreateUser(ExtMessengerUserDTO model)
        {
            var integration = this.Integration;
            var user = TryGetUser(integration.Id, model.UniqueId);
            return (ExtMessengerUserDTO)DBService.TryCreateEntity(DB.ExtMessengerUsers, model, (entity) =>
            {
                entity.ExtMessengerIntegrationId = integration.Id;
            });
        }

        #endregion








        #region Private methods 

        private ExtMessengerUser TryGetUser(int integrationId, string uniqueId)
        {
            var user = DB.ExtMessengerUsers.FirstOrDefault(o => o.UniqueId == uniqueId
                                                             && o.ExtMessengerIntegrationId == integrationId
                                                             && !o.IsDeleted);
            if (user != null)
            {
                throw new Exception403("Пользователь с данным UniqueId уже существует");
            }
            return user;
        }


        #endregion
    }
}
