using Alfateam.Messenger.Lib.Abstractions.Modules;
using Alfateam.Messenger.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Lib.Modules.Instagram
{
    public class InstagramMessagesModule : MessagesModule
    {
        private InstagramMessenger Messenger;
        public InstagramMessagesModule(InstagramMessenger messenger)
        {
            Messenger = messenger;
        }


        public override async Task DeleteMessage(string chatId, string messageId, bool forAll)
        {
            throw new NotImplementedException();
        }

        public override async Task EditMessage(string chatId, string messageId, string text)
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

        public override async Task SendStickerMessage(string chatId, string stickerId)
        {
            throw new NotImplementedException();
        }

        public override async Task SendTextMessage(string chatId, string message, List<AbsMessageAttachment> attachments = null)
        {
            throw new NotImplementedException();
        }

        public override async Task SendTyping(string chatId)
        {
            throw new NotImplementedException();
        }

        public override async Task SendVoiceMessage(string chatId, byte[] message)
        {
            throw new NotImplementedException();
        }
    }
}
