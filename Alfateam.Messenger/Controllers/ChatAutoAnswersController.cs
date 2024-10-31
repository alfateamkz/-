using Alfateam.Messenger.API.Abstractions;
using Alfateam.Messenger.API.Models;
using Alfateam.Messenger.Models.DTO.General.Chats;
using Alfateam.Messenger.Models.General.Chats;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.Messenger.API.Controllers
{
    public class ChatAutoAnswersController : AbsMessengerController
    {
        public ChatAutoAnswersController(ControllerParams @params) : base(@params)
        {
        }



        [HttpGet, Route("GetHelloAutoMessageSettings")]
        public async Task<HelloAutoMessageSettingsDTO> GetHelloAutoMessageSettings()
        {
            var settings = DB.HelloAutoMessageSettings.FirstOrDefault(o => !o.IsDeleted && o.AccountId == this.AccountId);
            return (HelloAutoMessageSettingsDTO)new HelloAutoMessageSettingsDTO().CreateDTO(settings);
        }

        [HttpGet, Route("GetOfflineAutoMessageSettings")]
        public async Task<OfflineAutoMessageSettingsDTO> GetOfflineAutoMessageSettings()
        {
            var settings = DB.OfflineAutoMessageSettings.FirstOrDefault(o => !o.IsDeleted && o.AccountId == this.AccountId);
            return (OfflineAutoMessageSettingsDTO)new OfflineAutoMessageSettingsDTO().CreateDTO(settings);
        }







        [HttpPut, Route("UpdateHelloAutoMessageSettings")]
        public async Task<HelloAutoMessageSettingsDTO> UpdateHelloAutoMessageSettings(HelloAutoMessageSettingsDTO model)
        {
            var settings = DB.HelloAutoMessageSettings.FirstOrDefault(o => !o.IsDeleted && o.AccountId == this.AccountId);
            return (HelloAutoMessageSettingsDTO)DBService.TryUpdateEntity(DB.HelloAutoMessageSettings, model, settings);
        }

        [HttpPut, Route("UpdateOfflineAutoMessageSettings")]
        public async Task<OfflineAutoMessageSettingsDTO> UpdateOfflineAutoMessageSettings(OfflineAutoMessageSettingsDTO model)
        {
            var settings = DB.OfflineAutoMessageSettings.FirstOrDefault(o => !o.IsDeleted && o.AccountId == this.AccountId);
            return (OfflineAutoMessageSettingsDTO)DBService.TryUpdateEntity(DB.OfflineAutoMessageSettings, model, settings);
        }
    }
}
