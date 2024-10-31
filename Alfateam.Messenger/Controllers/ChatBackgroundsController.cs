using Alfateam.Core.Enums;
using Alfateam.Messenger.API.Abstractions;
using Alfateam.Messenger.API.Models;
using Alfateam.Messenger.Models;
using Alfateam.Messenger.Models.DTO;
using Alfateam.Messenger.Models.DTO.General.Chats;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.Annotations;

namespace Alfateam.Messenger.API.Controllers
{
    public class ChatBackgroundsController : AbsMessengerController
    {
        public ChatBackgroundsController(ControllerParams @params) : base(@params)
        {
        }

        [HttpGet, Route("GetChatBackgrounds")]
        public async Task<IEnumerable<ChatBackgroundDTO>> GetChatBackgrounds(bool isDefaultBackgrounds)
        {
            IEnumerable<ChatBackground> backgrounds = new List<ChatBackground>();
            if (isDefaultBackgrounds)
            {
                backgrounds = ChatMiscService.GetDefaultChatBackgrounds();
            }
            else
            {
                backgrounds = ChatMiscService.GetPrivateChatBackgrounds(this.AccountId);
            }

            return new ChatBackgroundDTO().CreateDTOs(backgrounds).Cast<ChatBackgroundDTO>();
        }



        [HttpPost, Route("CreateChatBackground")]
        [SwaggerOperation("Необходимо загрузить файл по имени file")]
        public async Task<ChatBackgroundDTO> CreateChatBackground(IFormFile file)
        {
            var background = new ChatBackground
            {
                Filepath = FilesService.TryUploadFile(file, FileType.Image),
                AccountId = this.AccountId
            };
            background = DBService.CreateEntity(DB.ChatBackgrounds, background);
            return (ChatBackgroundDTO)new ChatBackgroundDTO().CreateDTO(background);
        }



        [HttpDelete, Route("DeleteChatBackground")]
        public async Task DeleteChatBackground(int id)
        {
            var background = DBService.TryGetOne(ChatMiscService.GetPrivateChatBackgrounds(this.AccountId), id);
            DBService.TryDeleteEntity(DB.ChatBackgrounds, background);
        }







    }
}
