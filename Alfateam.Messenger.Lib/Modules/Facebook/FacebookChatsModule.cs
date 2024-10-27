﻿using Alfateam.Messenger.Lib.Abstractions.Modules;
using Alfateam.Messenger.Models.Abstractions.Chats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Lib.Modules.Facebook
{
    public class FacebookChatsModule : ChatsModule
    {
        private FacebookMessenger Messenger;
        public FacebookChatsModule(FacebookMessenger messenger)
        {
            Messenger = messenger;
        }


        public override async Task<Chat> CreateChat(Chat chat)
        {
            throw new NotImplementedException();
        }

        public override async Task DeleteChat(string id)
        {
            throw new NotImplementedException();
        }

        public override async Task<Chat> GetChat(string id)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<Chat>> GetChats(int offset, int count)
        {
            throw new NotImplementedException();
        }
    }
}
