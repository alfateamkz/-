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
        public static GroupChat ConvertVKGroupChatToUniversal(VkNet.Model.Chat chat)
        {
            GroupChat universal = new GroupChat
            {
                ChatId = chat.Id.ToString(),
                ChatPhotoPath = chat.Photo200,
                AdminId = chat.AdminId.ToString(),
                Title = chat.Title,
            };



            return universal;
        }
        public static PrivateChat ConvertVKPrivateChatToUniversal(VkApi api, VkNet.Model.Conversation chat)
        {
            PrivateChat universal = new PrivateChat
            {
                ChatId = "",
                PeerId = chat.Peer.Id.ToString(),
                OurUserId = api.UserId.ToString(),
                Messages = new List<Models.Abstractions.Message>
                {

                },
            };



            return universal;
        }


        public static Models.Abstractions.Message ConvertVKTextMessageToUniversal()
        {
            throw new Exception();
        }
    }
}
