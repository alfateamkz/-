using Alfateam.Messenger.Lib.Abstractions;
using Alfateam.Messenger.Lib.Enums;
using Alfateam.Messenger.Lib.Modules.Telegram;
using Alfateam.Messenger.Lib.Modules.VK;
using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.Accounts.SocialNetworks;
using Alfateam.Messenger.Models.Chats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkNet;
using VkNet.Model;

namespace Alfateam.Messenger.Lib
{
    public class VkMessenger : AbsMessenger
    {
        public const ulong ApplicationID = 1;
        public VkApi VkApi;
        public VKAccount VKAccount => Account as VKAccount;
        public VkMessenger(VKAccount account) : base(account)
        {
            VkApi = new VkApi();

            Auth = new VKAuthModule(this);
            Chats = new VKChatsModule(this);
            Messages = new VKMessagesModule(this);
            Peers = new VKPeersModule(this);
            Stickers = new VKStickersModule(this);
        }


    }
}
