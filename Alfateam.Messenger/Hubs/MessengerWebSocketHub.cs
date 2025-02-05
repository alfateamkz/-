using Alfateam.Core.Exceptions;
using Alfateam.Messenger.API.Abstractions;
using Alfateam.Messenger.API.Enums;
using Alfateam.Messenger.API.Models;
using Alfateam.Messenger.Lib.Enums;
using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.Abstractions.Messages;
using Alfateam.Messenger.Models.Chats;
using Alfateam.Messenger.Models.DTO.Abstractions;
using Alfateam.Messenger.Models.DTO.Abstractions.Messages;
using Alfateam.Messenger.Models.Enums;
using Alfateam.Messenger.Models.General.GroupChats;
using Alfateam.Messenger.Models.General.GroupChats.Members;
using Alfateam.Messenger.Models.Messages.UserMessages;
using Alfateam.Messenger.Models.Peers;
using Alfateam.Messenger.Models.Stickers.Alfateam;
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


        #region Подключение к сокету и все, что с этим связано
        public List<MessengerWSConnectedUser> ConnectedUsers { get; set; } = new List<MessengerWSConnectedUser>();
        public override Task OnConnectedAsync()
        {
            MessengerType type = default;
            int id = 0;

            if(Account != null)
            {
                id = (int)AccountId;
                type = MessengerType.ExtMessenger;
            }
            else if (!string.IsNullOrEmpty(ExtMessengerSecret))
            {
                type = MessengerType.ExtAlfateamIntegration;
                id = (int)ExtMessengerUserId;
            }
            else
            {
                type = MessengerType.Alfateam;
                id = this.AuthorizedUser.Id;
            }


            ConnectedUsers.Add(new MessengerWSConnectedUser
            {
                ConnectionId = this.Context.ConnectionId,
                Id = id,
                Type = type
            });
       
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            var found = ConnectedUsers.FirstOrDefault(o => o.ConnectionId == this.Context.ConnectionId);
            if (found != null)
            {
                ConnectedUsers.Remove(found);
            }

            return base.OnDisconnectedAsync(exception);
        }


        protected async Task SendAsyncOnlyToChatMembers(string chatId, string method, object arg1)
        {
            if (Account != null)
            {
                var connectionId = ConnectedUsers.FirstOrDefault(o => o.Id == AccountId && o.Type == MessengerType.ExtMessenger)!.ConnectionId;
                await this.Clients.User(connectionId).SendAsync(method, arg1);
            }
            else if (!string.IsNullOrEmpty(ExtMessengerSecret))
            {
                var membersIds = AlfateamMessengerService.GetAlfateamExtMessengerChatMembersIds(Convert.ToInt32(chatId), (int)this.ExtMessengerUserId);
                var connectedIds = GetConnectedIds(membersIds);

                await this.Clients.Clients(connectedIds).SendAsync(method, arg1);
            }
            else
            {
                var membersIds = AlfateamMessengerService.GetAlfateamChatMembersIds(Convert.ToInt32(chatId), this.AuthorizedUser.Id);
                var connectedIds = GetConnectedIds(membersIds);

                await this.Clients.Clients(connectedIds).SendAsync(method, arg1);
            }

            await this.Clients.All.SendAsync(method, arg1);
        }
        protected IEnumerable<string> GetConnectedIds(IEnumerable<int> membersIds)
        {
            var list = new List<string>();

            foreach(var memberId in membersIds)
            {
                MessengerWSConnectedUser connectedUser = null;
                if (!string.IsNullOrEmpty(ExtMessengerSecret))
                {
                    connectedUser = ConnectedUsers.FirstOrDefault(o => o.Id == memberId && o.Type == MessengerType.ExtAlfateamIntegration);
                }
                else
                {
                    connectedUser = ConnectedUsers.FirstOrDefault(o => o.Id == memberId && o.Type == MessengerType.Alfateam);
                }

                if(connectedUser != null)
                {
                    list.Add(connectedUser.ConnectionId);
                }
            }

            return list;
        }

        #endregion







        #region Чаты
        public async Task CreateChat(ChatBaseDTO model)
        {
            ChatBase newChat = null;
            if(Account != null)
            {
                newChat = await Messenger.Chats.CreateChat(model.CreateDBModelFromDTO());
            }
            else if (!string.IsNullOrEmpty(ExtMessengerSecret))
            {
                newChat = AlfateamMessengerService.TryCreateChat((int)this.ExtMessengerUserId, AlfateamMessengerType.ExtIntegration,model);
            }
            else
            {
                newChat = AlfateamMessengerService.TryCreateChat(this.AuthorizedUser.Id, AlfateamMessengerType.Internal, model);  
            }

            var dtoModel = (ChatBaseDTO)new ChatBaseDTO().CreateDTO(newChat);
            await SendAsyncOnlyToChatMembers(newChat.Id.ToString(), "ChatCreated", dtoModel);
        }
        public async Task EditChat(ChatBaseDTO model)
        {
            ChatBase editedChat = null;
            if (Account != null)
            {
                editedChat = await Messenger.Chats.EditChat(model.CreateDBModelFromDTO());
            }
            else if (!string.IsNullOrEmpty(ExtMessengerSecret))
            {
                editedChat = DBService.TryGetOne(AlfateamMessengerService.GetAvailableAlfateamExtMessengerChats((int)this.ExtMessengerUserId), model.Id);
                DBService.TryUpdateEntity(DB.Chats, model, editedChat);
            }
            else
            {
                editedChat = DBService.TryGetOne(AlfateamMessengerService.GetAvailableAlfateamChats(this.AuthorizedUser.Id), model.Id);
                DBService.TryUpdateEntity(DB.Chats, model, editedChat);
            }

            var dtoModel = (ChatBaseDTO)new ChatBaseDTO().CreateDTO(editedChat); 
            await SendAsyncOnlyToChatMembers(editedChat.Id.ToString(), "ChatCreated", dtoModel);
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
                //TODO: сделать ли удаление чатов
                throw new Exception400("Нельзя удалить чат в Alfateam");
            }
            else
            {
                //TODO: сделать ли удаление чатов
                throw new Exception400("Нельзя удалить чат в Alfateam");
            }

            await SendAsyncOnlyToChatMembers(chatId, "ChatDeleted", result);
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
            else
            {
                var typeAndId = GetTypeAndId();
                result = AlfateamMessengerService.TryDeleteMessage(typeAndId.Type, Convert.ToInt32(chatId), typeAndId.UserId, Convert.ToInt32(messageId), forAll);        
            }

            //TODO: message deleted result
            await SendAsyncOnlyToChatMembers(chatId, "MessageDeleted", result);
        }


        public async Task SendTextMessage(string chatId, string message, List<MessageAttachmentBase> attachments)
        {
            //TODO: MessageAttachments 
            //TODO: Forwarded and replied messages

            MessageBase createdMessage = null;
            if (Account != null)
            {
                createdMessage = await Messenger.Messages.SendTextMessage(chatId, message, attachments);
            }
            else
            {
                var typeAndId = GetTypeAndId();
                createdMessage = AlfateamMessengerService.TrySendTextMessage(typeAndId.Type, Convert.ToInt32(chatId), typeAndId.UserId, message, attachments);
            }

            var dtoModel = (MessageBaseDTO)new MessageBaseDTO().CreateDTO(createdMessage);
            await SendAsyncOnlyToChatMembers(chatId, "MessageCreated", dtoModel);
        }
        public async Task SendStickerMessage(string chatId, string stickerId)
        {
            MessageBase createdMessage = null;
            if (Account != null)
            {
                createdMessage = await Messenger.Messages.SendStickerMessage(chatId, stickerId);
            }
            else
            {
                var typeAndId = GetTypeAndId();
                createdMessage = AlfateamMessengerService.TrySendStickerMessage(typeAndId.Type, Convert.ToInt32(chatId), typeAndId.UserId, Convert.ToInt32(stickerId));
            }

            var dtoModel = (MessageBaseDTO)new MessageBaseDTO().CreateDTO(createdMessage);
            await SendAsyncOnlyToChatMembers(chatId, "MessageCreated", dtoModel);
        }
        public async Task SendVoiceMessage(string chatId, byte[] message)
        {
            //TODO: валидация гс из массива байтов

            MessageBase createdMessage = null;
            if (Account != null)
            {
                createdMessage = await Messenger.Messages.SendVoiceMessage(chatId, message);
            }
            else
            {
                var typeAndId = GetTypeAndId();
                createdMessage = AlfateamMessengerService.TrySendVoiceMessage(typeAndId.Type, Convert.ToInt32(chatId), typeAndId.UserId, message);
            }

            var dtoModel = (MessageBaseDTO)new MessageBaseDTO().CreateDTO(createdMessage);
            await SendAsyncOnlyToChatMembers(chatId, "MessageCreated", dtoModel);
        }
        public async Task EditTextMessage(string chatId, string messageId, string text)
        {
            MessageBase editedMessage = null;
            if (Account != null)
            {
                editedMessage = await Messenger.Messages.EditMessage(chatId, messageId, text);
            }
            else
            {
                var typeAndId = GetTypeAndId();
                editedMessage = AlfateamMessengerService.TryEditTextMessage(typeAndId.Type, Convert.ToInt32(chatId), typeAndId.UserId, Convert.ToInt32(messageId), text);
            }

            var dtoModel = (MessageBaseDTO)new MessageBaseDTO().CreateDTO(editedMessage);
            await SendAsyncOnlyToChatMembers(chatId, "MessageEdited", dtoModel);
        }


        public async Task SendTyping(string chatId)
        {
            if (Account != null)
            {
                await Messenger.Messages.SendTyping(chatId);
            }
            await SendAsyncOnlyToChatMembers(chatId, "TypingMessage", null);
        }
        public async Task SendRecordingVoiceMessage(string chatId)
        {
            if (Account != null)
            {
                await Messenger.Messages.SendRecordingVoiceMessage(chatId);
            }
            await SendAsyncOnlyToChatMembers(chatId, "RecordingVoiceMessage", null);

        }


        #endregion








        #region Private methods

        private MessengerTypeAndUserId GetTypeAndId()
        {
            if (string.IsNullOrEmpty(ExtMessengerSecret))
            {
                return new MessengerTypeAndUserId(AlfateamMessengerType.Internal, this.AuthorizedUser.Id);
            }
            return new MessengerTypeAndUserId(AlfateamMessengerType.ExtIntegration, (int)this.ExtMessengerUserId);
        }


        #endregion
    }
}
