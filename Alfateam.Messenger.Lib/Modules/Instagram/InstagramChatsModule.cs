using Alfateam.Messenger.Lib.Abstractions.Modules;
using Alfateam.Messenger.Lib.Enums;
using Alfateam.Messenger.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Lib.Modules.Instagram
{
    public class InstagramChatsModule : ChatsModule
    {
        private InstagramMessenger Messenger;
        public InstagramChatsModule(InstagramMessenger messenger)
        {
            Messenger = messenger;
        }


        public override async Task<ChatBase> CreateChat(ChatBase chat)
        {
            throw new NotImplementedException();
        }
        public override async Task<ChatBase> EditChat(ChatBase chat)
        {
            throw new NotImplementedException();
        }

        public override async Task<ChatDeletionResult> DeleteChat(string id)
        {
            throw new NotImplementedException();
        }

        public override async Task<ChatBase> GetChat(string id)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<ChatBase>> GetChats(int offset, int count)
        {
            throw new NotImplementedException();
        }
    }
}
