using Alfateam.Messenger.Lib.Abstractions;
using Alfateam.Messenger.Lib.Modules.Facebook;
using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.Accounts.SocialNetworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Lib
{
    public class FacebookMessenger : AbsMessenger
    {
        public FacebookAccount FacebookAccount => Account as FacebookAccount;
        public FacebookMessenger(FacebookAccount account) : base(account)
        {
            Auth = new FacebookAuthModule(this);
            Chats = new FacebookChatsModule(this);
            Messages = new FacebookMessagesModule(this);
            Peers = new FacebookPeersModule(this);
            Stickers = new FacebookStickersModule(this);
        }
    }
}
