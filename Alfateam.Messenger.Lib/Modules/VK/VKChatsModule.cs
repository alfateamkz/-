using Alfateam.Messenger.Lib.Abstractions.Modules;
using Alfateam.Messenger.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet;

namespace Alfateam.Messenger.Lib.Modules.VK
{
    public class VKChatsModule : ChatsModule
    {

        private VkMessenger Messenger;
        public VKChatsModule(VkMessenger messenger)
        {
            Messenger = messenger;
        }


        public override async Task<Models.Abstractions.Chat> CreateChat(Models.Abstractions.Chat chat)
        {
            throw new NotImplementedException();
        }

        public override async Task DeleteChat(string id)
        {
            throw new NotImplementedException();
        }

        public override async Task<Models.Abstractions.Chat> GetChat(string id)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<Models.Abstractions.Chat>> GetChats(int offset, int count)
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
