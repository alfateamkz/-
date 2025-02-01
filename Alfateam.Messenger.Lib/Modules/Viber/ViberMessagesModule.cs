using Alfateam.Messenger.Lib.Abstractions.Modules;
using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Lib.Modules.Viber
{
    public class ViberMessagesModule : MessagesModule
    {
        private ViberMessenger Messenger;
        public ViberMessagesModule(ViberMessenger messenger)
        {
            Messenger = messenger;
        }


        public override Task<bool> DeleteMessage(string chatId, string messageId, bool forAll)
        {
            throw new NotImplementedException();
        }

        public override Task<MessageBase> EditMessage(string chatId, string messageId, string text)
        {
            throw new NotImplementedException();
        }

        public override Task<MessageBase> GetMessage(string chatId, string messageId)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<MessageBase>> GetMessages(string chatId, int offset, int count)
        {
            throw new NotImplementedException();
        }

        public override Task SendRecordingVoiceMessage(string chatId)
        {
            throw new NotImplementedException();
        }

        public override Task<MessageBase> SendStickerMessage(string chatId, string stickerId)
        {
            throw new NotImplementedException();
        }

        public override Task<MessageBase> SendTextMessage(string chatId, string message, List<MessageAttachmentBase> attachments = null)
        {
            throw new NotImplementedException();
        }

        public override Task SendTyping(string chatId)
        {
            throw new NotImplementedException();
        }

        public override Task<MessageBase> SendVoiceMessage(string chatId, byte[] message)
        {
            throw new NotImplementedException();
        }
    }
}
