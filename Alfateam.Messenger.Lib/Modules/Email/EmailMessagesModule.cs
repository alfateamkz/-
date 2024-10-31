using Alfateam.Messenger.Lib.Abstractions.Modules;
using Alfateam.Messenger.Models.Abstractions.Attachments;
using Alfateam.Messenger.Models.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Lib.Modules.Email
{
    public class EmailMessagesModule : MessagesModule
    {
        private EmailMessenger Messenger;
        public EmailMessagesModule(EmailMessenger messenger)
        {
            Messenger = messenger;
        }

        public override async Task<bool> DeleteMessage(string chatId, string messageId, bool forAll)
        {
            throw new NotImplementedException();
        }

        public override async Task<Message> EditMessage(string chatId, string messageId, string text)
        {
            throw new NotImplementedException();
        }

        public override async Task<Message> GetMessage(string chatId, string messageId)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<Message>> GetMessages(string chatId, int offset, int count)
        {
            throw new NotImplementedException();
        }

        public override async Task SendRecordingVoiceMessage(string chatId)
        {
            throw new NotImplementedException();
        }

        public override async Task<Message> SendStickerMessage(string chatId, string stickerId)
        {
            throw new NotImplementedException();
        }

        public override async Task<Message> SendTextMessage(string chatId, string message, List<MessageAttachment> attachments = null)
        {
            throw new NotImplementedException();
        }

        public override async Task SendTyping(string chatId)
        {
            throw new NotImplementedException();
        }

        public override async Task<Message> SendVoiceMessage(string chatId, byte[] message)
        {
            throw new NotImplementedException();
        }
    }
}
