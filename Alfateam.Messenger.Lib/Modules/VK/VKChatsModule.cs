using Alfateam.Messenger.Lib.Abstractions.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkNet;
using VkNet.Model;
using Alfateam.Messenger.Lib.Enums;
using Alfateam.Messenger.Models.Abstractions;

namespace Alfateam.Messenger.Lib.Modules.VK
{
    public class VKChatsModule : ChatsModule
    {

        private VkMessenger Messenger;
        public VKChatsModule(VkMessenger messenger)
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
            var response = Messenger.VkApi.Messages.GetConversations(new GetConversationsParams
            {
                Count = (ulong)count,
                Offset = (ulong)offset,
                Extended = true,
            });




            throw new NotImplementedException();
        }
    }
}
