using Alfateam.DB;
using Alfateam.Messenger.Lib.Abstractions.Modules;
using Alfateam.Messenger.Lib.Enums;
using Alfateam.Messenger.Models.Abstractions.Chats;
using Alfateam.Messenger.Models.Abstractions.Messages.Alfateam;
using Alfateam.Messenger.Models.Chats.Alfateam;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Lib.Modules.Alfateam
{
    public class AlfateamChatsModule : ChatsModule
    {
        private AlfateamMessenger Messenger;
        public AlfateamChatsModule(AlfateamMessenger messenger)
        {
            Messenger = messenger;
        }

        public override async Task<Chat> CreateChat(Chat chat)
        {
            throw new NotImplementedException();
        }
        public override async Task<Chat> EditChat(Chat chat)
        {
            throw new NotImplementedException();
        }

        public override async Task<ChatDeletionResult> DeleteChat(string id)
        {
            throw new NotImplementedException();
        }

        public override async Task<Chat> GetChat(string id)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<Chat>> GetChats(int offset, int count)
        {
            var alfateamChats = Messenger.DB.Chats.Where(o => o is AlfateamMessengerChat).Cast<AlfateamMessengerChat>();
            var alfateamPrivateChats = alfateamChats.Where(o => o is AlfateamPrivateChat).Cast<AlfateamPrivateChat>();
            var alfateamGroupChats = alfateamChats.Where(o => o is AlfateamGroupChat).Cast<AlfateamGroupChat>();


            var chatsAndLastUpdateTimes = new Dictionary<DateTime, AlfateamMessengerChat>();


            var myPrivateChats = alfateamPrivateChats.Where(o => o.CreatedById == Messenger.Account.Id
                                                            || o.ReceiverId == Messenger.Account.Id);
            foreach (var chat in myPrivateChats)
            {
                var lastMessage = Messenger.DB.Messages.Where(o => o is AlfateamMessengerMessage)
                                                       .Cast<AlfateamMessengerMessage>()
                                                       .Where(o => o.AlfateamMessengerChatId == chat.Id && !o.IsDeleted)
                                                       .LastOrDefault();    
                if(lastMessage != null)
                {
                    chatsAndLastUpdateTimes.Add(lastMessage.CreatedAt, chat);
                }
                else
                {
                    chatsAndLastUpdateTimes.Add(chat.CreatedAt, chat);
                }
            }




            return chatsAndLastUpdateTimes.OrderByDescending(o => o.Value).Select(o => o.Value);
        }
    }
}
