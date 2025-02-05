using Alfateam.Messenger.API.Abstractions;
using Alfateam.Messenger.API.Models;
using Alfateam.Messenger.Lib.Enums;
using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.Chats;
using Alfateam.Messenger.Models.DTO.Abstractions;
using Alfateam.Messenger.Models.DTO.Abstractions.Messages;
using Alfateam.Messenger.Models.Peers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot.Types;
using static TdLib.TdApi;

namespace Alfateam.Messenger.API.Controllers.Messenger
{
    public class MessengerChatsController : AbsMessengerController
    {
        public MessengerChatsController(ControllerParams @params) : base(@params)
        {
        }

        #region Получение списка чатов

        [HttpGet, Route("GetChats")]
        public async Task<IEnumerable<ChatBaseDTO>> GetChats(int offset = 0, int count = 20)
        {
            IEnumerable<ChatBase> chats = null;
            if (Account != null)
            {
                chats = await Messenger.Chats.GetChats(offset, count);
            }
            else if (!string.IsNullOrEmpty(ExtMessengerSecret))
            {
                chats = AlfateamMessengerService.GetAvailableAlfateamExtMessengerChats((int)this.ExtMessengerUserId);
            }
            else
            {
                chats = AlfateamMessengerService.GetAvailableAlfateamChats(this.AuthorizedUser.Id);
            }

            return new ChatBaseDTO().CreateDTOs(chats).Cast<ChatBaseDTO>();
        }

        [HttpGet, Route("GetChat")]
        public async Task<ChatBaseDTO> GetChat(string chatId)
        {
            ChatBase chat = null;
            if(Account != null)
            {
                chat = await Messenger.Chats.GetChat(chatId);
            }
            else if (!string.IsNullOrEmpty(ExtMessengerSecret))
            {
                chat = AlfateamMessengerService.GetAvailableAlfateamExtMessengerChats((int)this.ExtMessengerUserId)
                                               .FirstOrDefault(o => o.Id == Convert.ToInt32(chatId));
            }
            else
            {
                chat = AlfateamMessengerService.GetAvailableAlfateamChats(this.AuthorizedUser.Id)
                                               .FirstOrDefault(o => o.Id == Convert.ToInt32(chatId));
            }

            ThrowIfNull(chat);
            return (ChatBaseDTO)new ChatBaseDTO().CreateDTO(chat);
        }

        #endregion








     
    }
}
