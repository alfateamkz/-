using Alfateam.Messenger.Models.Abstractions.Chats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Lib.Abstractions.Modules
{
    public abstract class ChatsModule
    {
        public abstract Task<IEnumerable<Chat>> GetChats(int offset, int count);
        public abstract Task<Chat> GetChat(string id);
        public abstract Task<Chat> CreateChat(Chat chat);
        public abstract Task DeleteChat(string id);
    }
}
