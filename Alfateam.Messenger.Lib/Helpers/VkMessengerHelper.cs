using Alfateam.Messenger.Models.Abstractions.Messages;
using Alfateam.Messenger.Models.Chats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkNet;

namespace Alfateam.Messenger.Lib.Helpers
{
    public static class VkMessengerHelper
    {
        public static ExternalGroupChat ConvertVKGroupChatToUniversal(VkNet.Model.Chat chat)
        {
            ExternalGroupChat universal = new ExternalGroupChat
            {
                ChatId = chat.Id.ToString(),
                ChatPhotoPath = chat.Photo200,
                AdminId = chat.AdminId.ToString(),
                Title = chat.Title,
            };



            return universal;
        }
        public static ExternalPrivateChat ConvertVKPrivateChatToUniversal(VkApi api, VkNet.Model.Conversation chat)
        {
            ExternalPrivateChat universal = new ExternalPrivateChat
            {
                ChatId = "",
                PeerId = chat.Peer.Id.ToString(),
                OurUserId = api.UserId.ToString(),
                Messages = new List<Message>
                {

                },
            };



            return universal;
        }


        public static Message ConvertVKTextMessageToUniversal()
        {
            throw new Exception();
        }
    }
}
