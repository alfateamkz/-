using Alfateam.DB;
using Alfateam.Messenger.Models;

namespace Alfateam.Messenger.API.Services
{
    public class ChatMiscService
    {
        private readonly MessengerDbContext DB;
        public ChatMiscService(MessengerDbContext db)
        {
            DB = db;
        }



        public IEnumerable<ChatNotificationSound> GetDefaultChatNotificationSounds()
        {
            return DB.ChatNotificationSounds.Where(o => !o.IsDeleted && o.AccountId == null);
        }
        public IEnumerable<ChatNotificationSound> GetPrivateChatNotificationSounds(int? accountId)
        {
            return DB.ChatNotificationSounds.Where(o => !o.IsDeleted && o.AccountId == accountId);
        }


        public IEnumerable<ChatBackground> GetDefaultChatBackgrounds()
        {
            return DB.ChatBackgrounds.Where(o => !o.IsDeleted && o.AccountId == null);
        }
        public IEnumerable<ChatBackground> GetPrivateChatBackgrounds(int? accountId)
        {
            return DB.ChatBackgrounds.Where(o => !o.IsDeleted && o.AccountId == accountId);
        }
    }
}
