using Alfateam.Messenger.API.Abstractions;
using Alfateam.Messenger.API.Models;
using Alfateam.Messenger.Lib.Enums;
using Alfateam.Messenger.Models.DTO.Abstractions.Chats;
using Alfateam.Messenger.Models.DTO.Abstractions.Messages;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.Messenger.API.Controllers.Messenger
{
    public class MessengerChatsController : AbsMessengerController
    {
        public MessengerChatsController(ControllerParams @params) : base(@params)
        {
        }


        [HttpGet, Route("GetChats")]
        public async Task<IEnumerable<ChatDTO>> GetChats(int offset = 0, int count = 20)
        {
            var chats = await Messenger.Chats.GetChats(offset, count);
            return new ChatDTO().CreateDTOs(chats).Cast<ChatDTO>();
        }

        [HttpGet, Route("GetChat")]
        public async Task<ChatDTO> GetChat(string chatId)
        {
            var chat = await Messenger.Chats.GetChat(chatId);
            return (ChatDTO)new ChatDTO().CreateDTO(chat);
        }

        [HttpPost, Route("CreateChat")]
        public async Task<ChatDTO> CreateChat(ChatDTO model)
        {
            var newChat = await Messenger.Chats.CreateChat(model.CreateDBModelFromDTO());
            return (ChatDTO)new ChatDTO().CreateDTO(newChat);
        }

        [HttpPut, Route("EditChat")]
        public async Task<ChatDTO> EditChat(ChatDTO model)
        {
            var newChat = await Messenger.Chats.EditChat(model.CreateDBModelFromDTO());
            return (ChatDTO)new ChatDTO().CreateDTO(newChat);
        }

        [HttpDelete, Route("DeleteChat")]
        public async Task<ChatDeletionResult> DeleteChat(string chatId)
        {
            return await Messenger.Chats.DeleteChat(chatId);
        }
    }
}
