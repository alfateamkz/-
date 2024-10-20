using Alfateam.Messenger.Models.Abstractions;
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
        public abstract Task DeleteMessage(string chatId, string messageId, bool forAll);


        public abstract Task SendTextMessage(string chatId, string message, List<AbsMessageAttachment> attachments = null);
        public abstract Task SendVoiceMessage(string chatId, byte[] message);
        public abstract Task SendStickerMessage(string chatId, string stickerId);



        public abstract Task EditMessage(string chatId, string messageId, string text);


        public abstract Task SendTyping(string chatId);
        public abstract Task SendRecordingVoiceMessage(string chatId);
    }
}
