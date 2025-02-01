using Alfateam.Messenger.Lib.Abstractions.Modules;
using DbFileAttachmentType = Alfateam.Messenger.Models.Enums.FileAttachmentType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkNet.Model;
using Alfateam.Messenger.Models.Abstractions.Messages;
using Alfateam.Messenger.Models.Abstractions;

namespace Alfateam.Messenger.Lib.Modules.VK
{
    public class VKMessagesModule : MessagesModule
    {
        private VkMessenger Messenger;
        public VKMessagesModule(VkMessenger messenger)
        {
            Messenger = messenger;
        }

        public override async Task<bool> DeleteMessage(string chatId, string messageId, bool forAll)
        {
            var result = Messenger.VkApi.Messages.Delete(new List<ulong> { Convert.ToUInt64(messageId) }, deleteForAll: forAll);

            throw new NotImplementedException();
        }

        public override async Task<MessageBase> GetMessage(string chatId, string messageId)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<MessageBase>> GetMessages(string chatId, int offset, int count)
        {

            throw new NotImplementedException();
        }

        public override async Task<MessageBase> SendStickerMessage(string chatId, string stickerId)
        {
            var result = Messenger.VkApi.Messages.SendSticker(new MessagesSendStickerParams
            {
                ChatId = Convert.ToInt64(chatId),
                StickerId = Convert.ToUInt32(stickerId),
            });

            throw new NotImplementedException();
        }
        public override async Task<MessageBase> SendTextMessage(string chatId, string message, List<MessageAttachmentBase> attachments = null)
        {
            var mediaAttachments = new List<MediaAttachment>();
            foreach(var attachment in attachments)
            {
                //if(attachment is FileMessageAttachment fileMessageAttachment)
                //{
                //    switch (fileMessageAttachment.Type)
                //    {
                //        case DbFileAttachmentType.Image:
                //            mediaAttachments.Add(new Photo()
                //            {
                //                CanComment = false,

                //            });
                //            break;
                //        case DbFileAttachmentType.Video:
                //            mediaAttachments.Add(new Video()
                //            {
                //                CanComment = false,

                //            });
                //            break;
                //        case DbFileAttachmentType.Audio:
                //            mediaAttachments.Add(new Audio()
                //            {
                               

                //            });
                //            break;
                //        case DbFileAttachmentType.Document:
                //            mediaAttachments.Add(new Document()
                //            {
                                
                //            });
                //            break;
                //    }
                //}    
            }

            var result = Messenger.VkApi.Messages.Send(new VkNet.Model.MessagesSendParams
            {
                ChatId = Convert.ToInt64(chatId),
                Message = message,
                Attachments = mediaAttachments,
                DontParseLinks = true,
                DisableMentions = true,
            });

            throw new NotImplementedException();
        }

        public override async Task<MessageBase> SendVoiceMessage(string chatId, byte[] message)
        {
            throw new NotImplementedException();
        }


        public override async Task SendTyping(string chatId)
        {
            Messenger.VkApi.Messages.SetActivity(chatId, VkNet.Enums.StringEnums.MessageActivityType.Typing);
        }
        public override async Task SendRecordingVoiceMessage(string chatId)
        {
            Messenger.VkApi.Messages.SetActivity(chatId, VkNet.Enums.StringEnums.MessageActivityType.Audiomessage);
        }





        public override async Task<MessageBase> EditMessage(string chatId, string messageId, string text)
        {
            var editResult = Messenger.VkApi.Messages.Edit(new MessageEditParams
            {
                KeepSnippets = true,
                DontParseLinks = true,
                PeerId = Convert.ToInt64(chatId),
                MessageId = Convert.ToInt64(messageId),
                Message = text
            });

            throw new NotImplementedException();
        }
    }
}
