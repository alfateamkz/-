using Alfateam.Messenger.API.Abstractions;
using Alfateam.Messenger.API.Models;
using Alfateam.Messenger.Models.DTO.Abstractions.Messages;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using static TdLib.TdApi;
using Telegram.Bot.Types;
using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.Abstractions.Messages;
using Alfateam.Messenger.Models.Messages.SystemMessages;
using Alfateam.Messenger.Models.Messages.UserMessages;

namespace Alfateam.Messenger.API.Controllers.Messenger
{
    public class MessengerMessagesController : AbsMessengerController
    {
        public MessengerMessagesController(ControllerParams @params) : base(@params)
        {
        }

         
        #region Получение сообщений

        [HttpGet, Route("GetMessages")]
        public async Task<IEnumerable<MessageBaseDTO>> GetMessages(string chatId, int offset = 0, int count = 20)
        {
            IEnumerable<MessageBase> messages = null;
            if (Account != null)
            {
                messages = await Messenger.Messages.GetMessages(chatId, offset, count);
            }
            else if (!string.IsNullOrEmpty(ExtMessengerSecret))
            {
                messages = AlfateamMessengerService.GetAvailableAlfateamExtMessengerChatMessages(Convert.ToInt32(chatId), (int)this.ExtMessengerUserId);
            }
            else
            {
                messages = AlfateamMessengerService.GetAvailableAlfateamChatMessages(Convert.ToInt32(chatId), this.AuthorizedUser.Id);
            }

            return new MessageBaseDTO().CreateDTOs(messages).Cast<MessageBaseDTO>();
        }

        [HttpGet, Route("GetMessage")]
        public async Task<MessageBaseDTO> GetMessage(string chatId, string messageId)
        {
            MessageBase message = null;
            if (Account != null)
            {
                message = await Messenger.Messages.GetMessage(chatId, messageId);
            }
            else if (!string.IsNullOrEmpty(ExtMessengerSecret))
            {
                message = AlfateamMessengerService.GetAvailableAlfateamExtMessengerChatMessages(Convert.ToInt32(chatId), (int)this.ExtMessengerUserId)
                                                  .FirstOrDefault(o => o.Id == Convert.ToInt32(messageId));
            }
            else
            {
                message = AlfateamMessengerService.GetAvailableAlfateamChatMessages(Convert.ToInt32(chatId), this.AuthorizedUser.Id)
                                                  .FirstOrDefault(o => o.Id == Convert.ToInt32(messageId));
            }

            ThrowIfNull(message);
            return (MessageBaseDTO)new MessageBaseDTO().CreateDTO(message);
        }

        #endregion



    }
}
