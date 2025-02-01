using Alfateam.Messenger.Lib.Enums;
using Alfateam.Messenger.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Lib.Abstractions.Modules
{
    public abstract class ChatsModule
    {
        public abstract Task<IEnumerable<ChatBase>> GetChats(int offset, int count);
        public abstract Task<ChatBase> GetChat(string id);
        public abstract Task<ChatBase> CreateChat(ChatBase chat);
        public abstract Task<ChatBase> EditChat(ChatBase chat);
        public abstract Task<ChatDeletionResult> DeleteChat(string id);
    }
}
