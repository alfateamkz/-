using Alfateam.Messenger.Models.Abstractions.Attachments;
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
        public abstract Task<IEnumerable<Message>> GetMessages(string chatId, int offset, int count);
        public abstract Task<Message> GetMessage(string chatId, string messageId);
        public abstract Task<bool> DeleteMessage(string chatId, string messageId, bool forAll);


        public abstract Task<Message> SendTextMessage(string chatId, string message, List<MessageAttachment> attachments = null);
        public abstract Task<Message> SendVoiceMessage(string chatId, byte[] message);
        public abstract Task<Message> SendStickerMessage(string chatId, string stickerId);



        public abstract Task<Message> EditMessage(string chatId, string messageId, string text);


        public abstract Task SendTyping(string chatId);
        public abstract Task SendRecordingVoiceMessage(string chatId);
    }
}
