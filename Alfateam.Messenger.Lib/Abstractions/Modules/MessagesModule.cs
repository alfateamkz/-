using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Lib.Abstractions.Modules
{
    public abstract class MessagesModule
    {
        public abstract Task<IEnumerable<MessageBase>> GetMessages(string chatId, int offset, int count);
        public abstract Task<MessageBase> GetMessage(string chatId, string messageId);
        public abstract Task<bool> DeleteMessage(string chatId, string messageId, bool forAll);


        public abstract Task<MessageBase> SendTextMessage(string chatId, string message, List<MessageAttachmentBase> attachments = null);
        public abstract Task<MessageBase> SendVoiceMessage(string chatId, byte[] message);
        public abstract Task<MessageBase> SendStickerMessage(string chatId, string stickerId);



        public abstract Task<MessageBase> EditMessage(string chatId, string messageId, string text);


        public abstract Task SendTyping(string chatId);
        public abstract Task SendRecordingVoiceMessage(string chatId);
    }
}
