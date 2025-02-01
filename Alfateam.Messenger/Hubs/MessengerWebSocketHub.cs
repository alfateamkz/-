using Alfateam.Messenger.API.Abstractions;
using Alfateam.Messenger.API.Models;
using Alfateam.Messenger.Lib.Enums;
using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.Abstractions.Messages;
using Alfateam.Messenger.Models.DTO.Abstractions;
using Alfateam.Messenger.Models.DTO.Abstractions.Messages;
using InstagramApiSharp.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Telegram.Bot.Types;
using static System.Net.Mime.MediaTypeNames;
using static TdLib.TdApi;

namespace Alfateam.Messenger.API.Hubs
{
    public class MessengerWebSocketHub : AbsHub
    {
        public MessengerWebSocketHub(ControllerParams @params) : base(@params)
        {
        }


        #region Чаты
        public async Task CreateChat(ChatBaseDTO model)
        {
            ChatBase newChat = null;
            if(Account != null)
            {
                newChat = await Messenger.Chats.CreateChat(model.CreateDBModelFromDTO());
            }
            else if (false)
            {

            }
            else
            {
               
            }

            var dtoModel = (ChatBaseDTO)new ChatBaseDTO().CreateDTO(newChat);
            await this.Clients.All.SendAsync("ChatCreated", dtoModel);
        }
        public async Task EditChat(ChatBaseDTO model)
        {
            ChatBase editedChat = null;
            if (Account != null)
            {
                editedChat = await Messenger.Chats.EditChat(model.CreateDBModelFromDTO());
            }
            else if (false)
            {

            }
            else
            {

            }


            var dtoModel = (ChatBaseDTO)new ChatBaseDTO().CreateDTO(editedChat); ;
            await this.Clients.All.SendAsync("ChatEdited", dtoModel);
        }
        public async Task DeleteChat(string chatId)
        {
            ChatDeletionResult result = default;
            if (Account != null)
            {
                result = await Messenger.Chats.DeleteChat(chatId);
            }
            else if (false)
            {

            }
            else
            {

            }

            await this.Clients.All.SendAsync("ChatDeleted", result);
        }

        #endregion

        #region Сообщения

        public async Task DeleteMessage(string chatId, string messageId, bool forAll)
        {
            bool result = default;
            if (Account != null)
            {
                result = await Messenger.Messages.DeleteMessage(chatId, messageId, forAll);
            }
            else if (false)
            {

            }
            else
            {

            }

            await this.Clients.All.SendAsync("MessageDeleted", result);
        }


        public async Task SendTextMessage(string chatId, string message, List<MessageAttachmentBase> attachments)
        {
            //TODO: MessageAttachments 

            MessageBase createdMessage = null;
            if (Account != null)
            {
                createdMessage = await Messenger.Messages.SendTextMessage(chatId, message, attachments);
            }
            else if (false)
            {

            }
            else
            {

            }

            var dtoModel = (MessageBaseDTO)new MessageBaseDTO().CreateDTO(createdMessage);
            await this.Clients.All.SendAsync("MessageCreated", dtoModel);
        }
        public async Task SendStickerMessage(string chatId, string stickerId)
        {
            MessageBase createdMessage = null;
            if (Account != null)
            {
                createdMessage = await Messenger.Messages.SendStickerMessage(chatId, stickerId);
            }
            else if (false)
            {

            }
            else
            {

            }

            var dtoModel = (MessageBaseDTO)new MessageBaseDTO().CreateDTO(createdMessage);
            await this.Clients.All.SendAsync("MessageCreated", dtoModel);
        }
        public async Task SendVoiceMessage(string chatId, [FromBody] byte[] message)
        {
            MessageBase createdMessage = null;
            if (Account != null)
            {
                createdMessage = await Messenger.Messages.SendVoiceMessage(chatId, message);
            }
            else if (false)
            {

            }
            else
            {

            }

            var dtoModel = (MessageBaseDTO)new MessageBaseDTO().CreateDTO(createdMessage);
            await this.Clients.All.SendAsync("MessageCreated", dtoModel);
        }
        public async Task EditTextMessage(string chatId, string messageId, string text)
        {
            MessageBase editedMessage = null;
            if (Account != null)
            {
                editedMessage = await Messenger.Messages.EditMessage(chatId, messageId, text);
            }
            else if (false)
            {

            }
            else
            {

            }

            var dtoModel = (MessageBaseDTO)new MessageBaseDTO().CreateDTO(editedMessage);
            await this.Clients.All.SendAsync("MessageEdited", dtoModel);
        }


        public async Task SendTyping(string chatId)
        {
            if (Account != null)
            {
                await Messenger.Messages.SendTyping(chatId);
            }
            else if (false)
            {

            }
            else
            {

            }
            await this.Clients.All.SendAsync("TypingMessage");
        }
        public async Task SendRecordingVoiceMessage(string chatId)
        {
            if (Account != null)
            {
                await Messenger.Messages.SendRecordingVoiceMessage(chatId);
            }
            else if (false)
            {

            }
            else
            {

            }
            await this.Clients.All.SendAsync("RecordingVoiceMessage");
            
        }


        #endregion
    }
}
