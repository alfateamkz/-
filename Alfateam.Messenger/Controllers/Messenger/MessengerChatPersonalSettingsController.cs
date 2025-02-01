using Alfateam.Core.Exceptions;
using Alfateam.Messenger.API.Abstractions;
using Alfateam.Messenger.API.Models;
using Alfateam.Messenger.Models;
using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.DTO.General.Chats;
using Alfateam.Messenger.Models.General.Chats;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Messenger.API.Controllers.Messenger
{
    public class MessengerChatPersonalSettingsController : AbsMessengerController
    {
        public MessengerChatPersonalSettingsController(ControllerParams @params) : base(@params)
        {
        }

        [HttpGet, Route("GetPersonalSettings")]
        public async Task<ChatPersonalSettingsDTO> GetPersonalSettings(int chatId)
        {
            var chat = TryGetChat(chatId);
            return (ChatPersonalSettingsDTO)new ChatPersonalSettingsDTO().CreateDTO(GetOrCreateChatPersonalSettings(chat));
        }

        [HttpPut, Route("SetChatsFolder")]
        public async Task SetChatsFolder(int folderId, [FromBody] List<int> chatIds)
        {
            var folder = TryGetChatFolder(folderId);

            var availableChats = GetAvailableChats();
            foreach(var chatId in chatIds)
            {
                var foundChat = availableChats.FirstOrDefault(o => o.Id == chatId);
                if(foundChat == null)
                {
                    throw new Exception404($"Чат с id={chatId} не найден");
                }

                var settings = GetOrCreateChatPersonalSettings(foundChat);
                settings.FolderId = folder.Id;
            }

            DBService.UpdateEntities(DB.Chats, availableChats);
        }


        [HttpPut, Route("SetChatPinnedOrder")]
        public async Task SetChatPinnedOrder(int chatId, int pinnedOrder = -1)
        {
            var settings = GetOrCreateChatPersonalSettings(TryGetChat(chatId));

            settings.PinnedOrder = pinnedOrder;
            DBService.UpdateEntity(DB.ChatPersonalSettings, settings);
        }


        [HttpPut, Route("SetChatBackground")]
        public async Task SetChatBackground(int chatId, int backgroundId)
        {
            var settings = GetOrCreateChatPersonalSettings(TryGetChat(chatId));

            settings.BackgroundId = TryGetAvailableChatBackground(backgroundId).Id;
            DBService.UpdateEntity(DB.ChatPersonalSettings, settings);
        }


        [HttpPut, Route("SetChatNotificationSound")]
        public async Task SetChatNotificationSound(int chatId, int soundId)
        {
            var settings = GetOrCreateChatPersonalSettings(TryGetChat(chatId));

            settings.Notifications.SoundId = GetAvailableChatNotificationSound(soundId).Id;
            DBService.UpdateEntity(DB.ChatPersonalSettings, settings);
        }


        [HttpPut, Route("UnmuteChat")]
        public async Task UnmuteChat(int chatId)
        {
            var settings = GetOrCreateChatPersonalSettings(TryGetChat(chatId));

            settings.Notifications.MutedBefore = null;
            DBService.UpdateEntity(DB.ChatPersonalSettings, settings);
        }

        [HttpPut, Route("MuteChat")]
        public async Task MuteChat(int chatId, DateTime muteBefore)
        {
            if(muteBefore < DateTime.UtcNow)
            {
                throw new Exception400("Невозможно установить время, которое уже прошло");
            }


            var settings = GetOrCreateChatPersonalSettings(TryGetChat(chatId));

            settings.Notifications.MutedBefore = muteBefore;
            DBService.UpdateEntity(DB.ChatPersonalSettings, settings);
        }







        #region Private methods


        private IEnumerable<ChatBase> GetAvailableChats()
        {
            var chats = DB.Chats.Include(o => o.PersonalSettings).ThenInclude(o => o.Folder)
                                .Include(o => o.PersonalSettings).ThenInclude(o => o.Background)
                                .Include(o => o.PersonalSettings).ThenInclude(o => o.Notifications)
                                .Where(o => !o.IsDeleted /*&& o.AccountId == this.AccountId*/);

            throw new NotImplementedException(); //TODO: GetAvailableChats

            return chats;
        }
        private ChatBase TryGetChat(int id)
        {
            return DBService.TryGetOne(GetAvailableChats(), id);
        }


        private ChatPersonalSettings GetOrCreateChatPersonalSettings(ChatBase chat)
        {
            var found = chat.PersonalSettings.FirstOrDefault(o => o.UserId == this.AccountId);
            if(found == null)
            {
                var chatPersonalSettings = new ChatPersonalSettings()
                {
                    UserId = (int)this.AccountId,
                    Notifications = new ChatNotificationSettings()
                    {
                        Sound = DB.ChatNotificationSounds.FirstOrDefault(o => o.AccountId == null && !o.IsDeleted)
                    },
                    Background = DB.ChatBackgrounds.FirstOrDefault(o => o.AccountId == null && !o.IsDeleted),
                };
                chat.PersonalSettings.Add(chatPersonalSettings);
                DBService.UpdateEntity(DB.Chats, chat);

                return chatPersonalSettings;
            }
            return found;
        }



        private IEnumerable<ChatBackground> GetAvailableChatBackgrounds()
        {
            var availableBackgrounds = new List<ChatBackground>();

            availableBackgrounds.AddRange(ChatMiscService.GetPrivateChatBackgrounds(this.AccountId));
            availableBackgrounds.AddRange(ChatMiscService.GetDefaultChatBackgrounds());

            return availableBackgrounds;
        }
        private ChatBackground TryGetAvailableChatBackground(int id)
        {
            return DBService.TryGetOne(GetAvailableChatBackgrounds(), id);
        }


        private IEnumerable<ChatNotificationSound> GetAvailableChatNotificationSounds()
        {
            var availableSounds = new List<ChatNotificationSound>();

            availableSounds.AddRange(ChatMiscService.GetPrivateChatNotificationSounds(this.AccountId));
            availableSounds.AddRange(ChatMiscService.GetDefaultChatNotificationSounds());

            return availableSounds;
        }
        private ChatNotificationSound GetAvailableChatNotificationSound(int id)
        {
            return DBService.TryGetOne(GetAvailableChatNotificationSounds(), id);
        }


        private ChatFolder TryGetChatFolder(int id)
        {
            var folders = DB.ChatFolders.Where(o => !o.IsDeleted && o.AccountId == this.AccountId);
            return DBService.TryGetOne(folders, id);
        }


        #endregion
    }
}
