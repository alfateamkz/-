using Alfateam.Messenger.API.Abstractions;
using Alfateam.Messenger.API.Models;
using Alfateam.Messenger.Models.DTO.Abstractions.Messages;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using static TdLib.TdApi;
using Telegram.Bot.Types;
using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.Abstractions.Messages;

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
            else if (false)
            {

            }
            else
            {
                messages = GetAvailableAlfateamChatMessages(Convert.ToInt32(chatId));
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
            else if (false)
            {

            }
            else
            {
                message = GetAvailableAlfateamChatMessages(Convert.ToInt32(chatId)).FirstOrDefault(o => o.Id == Convert.ToInt32(messageId));
            }

            ThrowIfNull(message);
            return (MessageBaseDTO)new MessageBaseDTO().CreateDTO(message);
        }

        #endregion



        #region Private get alfateam messages methods

        private IEnumerable<MessageBase> GetAvailableAlfateamChatMessages(int chatId)
        {
            ThrowIfAlfateamChatNotExistOrAvailable(chatId);

            throw new();
        }


        #endregion
    }
}
