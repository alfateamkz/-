using Alfateam.Messenger.Lib.Abstractions.Modules;
using Alfateam.Messenger.Models.Abstractions.Chats;
using MailKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Lib.Modules.Email
{
    public class EmailChatsModule : ChatsModule
    {
        private EmailMessenger Messenger;
        public EmailChatsModule(EmailMessenger messenger)
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
            await Messenger.Imap.Inbox.OpenAsync(MailKit.FolderAccess.ReadWrite);
            var messageSummaries = await Messenger.Imap.Inbox.FetchAsync(0,-1, new FetchRequest(MessageSummaryItems.All));
            foreach(var summary in messageSummaries)
            {
                var msg = await Messenger.Imap.Inbox.GetMessageAsync(summary.UniqueId);
                //msg.Rep
            }


            //chats.GroupBy(o => o.)

            await Messenger.Imap.Inbox.CloseAsync();

            throw new NotImplementedException();
        }


    }
}
