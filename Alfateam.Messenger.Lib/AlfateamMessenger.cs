using Alfateam.DB;
using Alfateam.Messenger.Lib.Abstractions;
using Alfateam.Messenger.Lib.Modules.Alfateam;
using Alfateam.Messenger.Lib.Modules.Instagram;
using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.Accounts;
using Alfateam.Messenger.Models.Accounts.Messengers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Lib
{
    public class AlfateamMessenger : AbsMessenger
    {

        public readonly MessengerDbContext DB;
        public AlfateamMessengerAccount AlfateamAccount => Account as AlfateamMessengerAccount;
        public AlfateamMessenger(AlfateamMessengerAccount account) : base(account)
        {
            Auth = new AlfateamAuthModule(this);
            Chats = new AlfateamChatsModule(this);
            Messages = new AlfateamMessagesModule(this);
            Peers = new AlfateamPeersModule(this);
            Stickers = new AlfateamStickersModule(this);

            DB = new MessengerDbContext();
        }
    }
}
