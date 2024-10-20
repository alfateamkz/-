using Alfateam.Messenger.Lib.Abstractions;
using Alfateam.Messenger.Lib.Modules.Email;
using Alfateam.Messenger.Lib.Modules.Telegram;
using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.Accounts;
using MailKit.Net.Imap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Lib
{
    public class EmailMessenger : AbsMessenger
    {
        public readonly ImapClient Imap;
        public EmailAccount EmailAccount => Account as EmailAccount;
        public EmailMessenger(EmailAccount account) : base(account)
        {
            Auth = new EmailAuthModule(this);
            Chats = new EmailChatsModule(this);
            Messages = new EmailMessagesModule(this);
            Peers = new EmailPeersModule(this);
            Stickers = new EmailStickersModule(this);

            Imap = new ImapClient();
        }
    }
}
