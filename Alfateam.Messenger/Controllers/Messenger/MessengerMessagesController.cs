using Alfateam.Messenger.API.Abstractions;
using Alfateam.Messenger.API.Models;
using Alfateam.Messenger.Models.Abstractions.Attachments;
using Alfateam.Messenger.Models.DTO.Abstractions.Messages;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using static TdLib.TdApi;
using Telegram.Bot.Types;

namespace Alfateam.Messenger.API.Controllers.Messenger
{
    public class MessengerMessagesController : AbsMessengerController
    {
        public MessengerMessagesController(ControllerParams @params) : base(@params)
        {
        }


        [HttpGet, Route("GetMessages")]
        public async Task<IEnumerable<MessageDTO>> GetMessages(string chatId, int offset = 0, int count = 20)
        {
            var messages = await Messenger.Messages.GetMessages(chatId, offset, count);
            return new MessageDTO().CreateDTOs(messages).Cast<MessageDTO>();
        }

        [HttpGet, Route("GetMessage")]
        public async Task<MessageDTO> GetMessage(string chatId, string messageId)
        {
            var message = await Messenger.Messages.GetMessage(chatId, messageId);
            return (MessageDTO)new MessageDTO().CreateDTO(message);
        }



        [HttpDelete, Route("DeleteMessage")]
        public async Task<bool> DeleteMessage(string chatId, string messageId, bool forAll)
        {
            return await Messenger.Messages.DeleteMessage(chatId, messageId, forAll);
        }



        [HttpPost, Route("SendTextMessage")]
        public async Task<MessageDTO> SendTextMessage(string chatId, string message)
        {
            var attachments = new List<MessageAttachment>();
            //TODO: MessageAttachments 

            var createdMessage = await Messenger.Messages.SendTextMessage(chatId, message, attachments);
            return (MessageDTO)new MessageDTO().CreateDTO(createdMessage);
        }

        [HttpPost, Route("SendStickerMessage")]
        public async Task<MessageDTO> SendStickerMessage(string chatId, string stickerId)
        {
            var createdMessage = await Messenger.Messages.SendStickerMessage(chatId, stickerId);
            return (MessageDTO)new MessageDTO().CreateDTO(createdMessage);
        }

        [HttpPost, Route("SendVoiceMessage")]
        public async Task<MessageDTO> SendVoiceMessage(string chatId, [FromBody] byte[] message)
        {
            var createdMessage = await Messenger.Messages.SendVoiceMessage(chatId, message);
            return (MessageDTO)new MessageDTO().CreateDTO(createdMessage);
        }





        [HttpPut, Route("EditTextMessage")]
        public async Task<MessageDTO> EditTextMessage(string chatId, string messageId, string text)
        {
            var editedMessage = await Messenger.Messages.EditMessage(chatId, messageId, text);
            return (MessageDTO)new MessageDTO().CreateDTO(editedMessage);
        }





        [HttpPut, Route("SendTyping")]
        public async Task SendTyping(string chatId)
        {
            await Messenger.Messages.SendTyping(chatId);
        }

        [HttpPut, Route("SendRecordingVoiceMessage")]
        public async Task SendRecordingVoiceMessage(string chatId)
        {
            await Messenger.Messages.SendRecordingVoiceMessage(chatId);
        }


    }
}
