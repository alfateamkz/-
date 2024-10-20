using Alfateam.Messenger.Lib.Abstractions.Modules;
using Alfateam.Messenger.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TdLib.TdApi.InputMessageContent;
using TdLib;
using NAudio.Wave;
using static TdLib.TdApi.InputFile;
using static TdLib.TdApi.MessageContent;
using Alfateam.Messenger.Models.Messages;
using static TdLib.TdApi.MessageReadDate;
using static TdLib.TdApi.ChatAction;

namespace Alfateam.Messenger.Lib.Modules.Telegram
{
    public class TelegramMessagesModule : MessagesModule
    {

        private TelegramMessenger Messenger;
        public TelegramMessagesModule(TelegramMessenger messenger)
        {
            Messenger = messenger;
        }


        public override async Task DeleteMessage(string chatId, string messageId, bool forAll)
        {
            var response = await Messenger.Client.DeleteMessagesAsync(Convert.ToInt64(chatId), new long[] { Convert.ToInt64(messageId) }, forAll);
        }

        public override async Task<Message> GetMessage(string chatId, string messageId)
        {
            var message = await Messenger.Client.GetMessageAsync(Convert.ToInt64(chatId), Convert.ToInt64(messageId));
            return await TransformTgMessageToUniversal(message);
        }

        public override async Task<IEnumerable<Message>> GetMessages(string chatId, int offset, int count)
        {
            var messagesResponse = await Messenger.Client.GetChatScheduledMessagesAsync(Convert.ToInt64(chatId));
            var tgMessages = messagesResponse.Messages_.Skip(offset).Take(count);

            throw new NotImplementedException();
        }




        public override async Task SendStickerMessage(string chatId, string stickerId)
        {
            throw new NotImplementedException();
        }

        public override async Task SendTextMessage(string chatId, string message, List<AbsMessageAttachment> attachments = null)
        {
            var msg = new InputMessageText
            {
                Text = new TdApi.FormattedText()
                {
                    Text = message,
                },
                ClearDraft = true,
                LinkPreviewOptions = new TdApi.LinkPreviewOptions
                {
                    ShowAboveText = false,
                    IsDisabled = true,
                }
            };
            await Messenger.Client.SendMessageAsync(chatId: Convert.ToInt64(chatId), inputMessageContent: msg);

            throw new NotImplementedException();
        }
        public override async Task SendVoiceMessage(string chatId, byte[] message)
        {
            var voiceMessageFilepath = SaveTempFile(message);
            using (var audioFileReader = new AudioFileReader(voiceMessageFilepath))
            {
                var voiceMsg = new InputMessageVoiceNote()
                {
                    VoiceNote = new InputFileLocal()
                    {
                        Path = voiceMessageFilepath,
                    },
                    Duration = (int)audioFileReader.TotalTime.TotalSeconds,
                    //Waveform = 
                };
                await Messenger.Client.SendMessageAsync(chatId: Convert.ToInt64(chatId), inputMessageContent: voiceMsg);
            }
            DeleteTempFile(voiceMessageFilepath);
        }






        public override async Task SendTyping(string chatId)
        {
            await Messenger.Client.SendChatActionAsync(chatId: Convert.ToInt64(chatId), action: new ChatActionTyping());
        }
        public override async Task SendRecordingVoiceMessage(string chatId)
        {
            await Messenger.Client.SendChatActionAsync(chatId: Convert.ToInt64(chatId), action: new ChatActionRecordingVoiceNote());
        }




        public override async Task EditMessage(string chatId, string messageId, string text)
        {
            var result = await Messenger.Client.EditMessageTextAsync(Convert.ToInt64(chatId), Convert.ToInt64(messageId), inputMessageContent: new InputMessageText()
            {
                Text = new TdApi.FormattedText
                {
                    Text = text
                }
            });
        }



        #region Private methods

        private string SaveTempFile(byte[] data)
        {
            var filename = Path.GetTempFileName();
            File.WriteAllBytes(filename, data);

            return filename;
        }
        private void DeleteTempFile(string filepath)
        {
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }
        }



        private async Task<Message> TransformTgMessageToUniversal(TdApi.Message tgMessage)
        {
            Message message = null;

            if (tgMessage.Content is MessageText textMsg)
            {
                message = new TextMessage
                {
                    Text = textMsg.Text.Text,
                };
            }
            else if(tgMessage.Content is MessageVoiceNote voiceMsg)
            {
               
                 message = new VoiceMessage
                 {
                     IsListened = voiceMsg.IsListened,
                     //Message = voiceMsg.VoiceNote.Voice.Remote.UniqueId.T,
                     //d
                 };
            }
            else if (tgMessage.Content is MessageSticker stickerMsg)
            {
                message = new StickerMessage
                {

                };
            }
            else
            {
                message = new TextMessage
                {
                    Text = $"Неподдерживаемый тип сообщения ({tgMessage.Content.GetType().Name})",
                };
            }



            if (tgMessage.CanGetReadDate)
            {
                var readAtResponse = await Messenger.Client.GetMessageReadDateAsync(tgMessage.ChatId, tgMessage.Id);
                if(readAtResponse is MessageReadDateRead readDateRead)
                {
                    message.ReadAt = DateTime.FromFileTimeUtc(readDateRead.ReadDate);
                    message.IsRead = true;
                }
            }

            return message;
        }

   
        #endregion
    }
}
