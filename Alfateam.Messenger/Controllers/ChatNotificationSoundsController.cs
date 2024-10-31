using Alfateam.Core.Enums;
using Alfateam.Messenger.API.Abstractions;
using Alfateam.Messenger.API.Models;
using Alfateam.Messenger.Models;
using Alfateam.Messenger.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Alfateam.Messenger.API.Controllers
{
    public class ChatNotificationSoundsController : AbsMessengerController
    {
        public ChatNotificationSoundsController(ControllerParams @params) : base(@params)
        {
        }



        [HttpGet, Route("GetChatNotificationSounds")]
        public async Task<IEnumerable<ChatNotificationSoundDTO>> GetChatNotificationSounds(bool isDefaultBackgrounds)
        {
            IEnumerable<ChatNotificationSound> backgrounds = new List<ChatNotificationSound>();
            if (isDefaultBackgrounds)
            {
                backgrounds = ChatMiscService.GetDefaultChatNotificationSounds();
            }
            else
            {
                backgrounds = ChatMiscService.GetPrivateChatNotificationSounds(this.AccountId);
            }

            return new ChatNotificationSoundDTO().CreateDTOs(backgrounds).Cast<ChatNotificationSoundDTO>();
        }



        [HttpPost, Route("CreateChatNotificationSound")]
        [SwaggerOperation("Необходимо загрузить файл по имени file")]
        public async Task<ChatNotificationSoundDTO> CreateChatNotificationSound(IFormFile file)
        {
            var sound = new ChatNotificationSound
            {
                Filepath = FilesService.TryUploadFile(file, FileType.Audio),
                AccountId = this.AccountId
            };
            sound = DBService.CreateEntity(DB.ChatNotificationSounds, sound);
            return (ChatNotificationSoundDTO)new ChatNotificationSoundDTO().CreateDTO(sound);
        }


        [HttpDelete, Route("DeleteChatNotificationSound")]
        public async Task DeleteChatNotificationSound(int id)
        {
            var sound = DBService.TryGetOne(ChatMiscService.GetPrivateChatNotificationSounds(this.AccountId), id);
            DBService.TryDeleteEntity(DB.ChatNotificationSounds, sound);
        }
    }
}
