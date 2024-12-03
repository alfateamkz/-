using Alfateam.Messenger.Lib.Abstractions.Modules;
using Alfateam.Messenger.Lib.Enums;
using Alfateam.Messenger.Lib.Modules.Telegram;
using Alfateam.Messenger.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Lib.Abstractions
{
    public abstract class AbsMessenger
    {
        public virtual MessengerMailingAccount Account { get; set; }
        public AbsMessenger(MessengerMailingAccount account)
        {
            if(account == null)
            {
                throw new NullReferenceException("Аккаунт не должен быть null");
            }
            this.Account = account;
        }

        public AuthModule Auth { get; protected set; }
        public ChatsModule Chats { get; protected set; }
        public MessagesModule Messages { get; protected set; }
        public PeersModule Peers { get; protected set; }
        public StickersModule Stickers { get; protected set; }


    }
}
