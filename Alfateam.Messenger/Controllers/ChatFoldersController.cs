using Alfateam.Messenger.API.Abstractions;
using Alfateam.Messenger.API.Models;
using Alfateam.Messenger.Models.DTO.General.Chats;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static TdLib.TdApi;

namespace Alfateam.Messenger.API.Controllers
{
    public class ChatFoldersController : AbsMessengerController
    {
        public ChatFoldersController(ControllerParams @params) : base(@params)
        {
        }

        [HttpGet, Route("GetChatFolders")]
        public async Task<IEnumerable<ChatFolderDTO>> GetChatFolders()
        {
            var folders = DB.ChatFolders.Where(o => !o.IsDeleted && o.AccountId == this.AccountId);
            return new ChatFolderDTO().CreateDTOs(folders).Cast<ChatFolderDTO>();
        }

        [HttpGet, Route("GetChatFolder")]
        public async Task<ChatFolderDTO> GetChatFolder(int id)
        {
            var folders = DB.ChatFolders.Where(o => !o.IsDeleted && o.AccountId == this.AccountId);
            return (ChatFolderDTO)new ChatFolderDTO().CreateDTO(DBService.TryGetOne(folders,id));
        }



        [HttpPost, Route("CreateChatFolder")]
        public async Task<ChatFolderDTO> CreateChatFolder(ChatFolderDTO model)
        {
            return (ChatFolderDTO)DBService.TryCreateEntity(DB.ChatFolders, model, (entity) =>
            {
                entity.AccountId = (int)this.AccountId;
            });
        }

        [HttpPut, Route("UpdateChatFolder")]
        public async Task<ChatFolderDTO> UpdateChatFolder(ChatFolderDTO model)
        {
            var folders = DB.ChatFolders.Where(o => !o.IsDeleted && o.AccountId == this.AccountId);
            var folder = DBService.TryGetOne(folders, model.Id);

            return (ChatFolderDTO)DBService.TryUpdateEntity(DB.ChatFolders, model, folder);
        }

        [HttpDelete, Route("DeleteChatFolder")]
        public async Task DeleteChatFolder(int id)
        {
            var folders = DB.ChatFolders.Where(o => !o.IsDeleted && o.AccountId == this.AccountId);
            var folder = DBService.TryGetOne(folders, id);

            var chatsWithThisFolder = DB.Chats.Include(o => o.PersonalSettings)
                                        .Where(o => o.PersonalSettings.Any(a => a.UserId == this.AccountId && a.FolderId == id));
            foreach(var chat in chatsWithThisFolder)
            {
                var personalSettings = chat.PersonalSettings.FirstOrDefault(o => o.UserId == this.AccountId);
                personalSettings.FolderId = null;
            }
            DBService.UpdateEntities(DB.Chats, chatsWithThisFolder);
            DBService.DeleteEntity(DB.ChatFolders, folder);
        }
    }
}
