﻿using Alfateam.Messenger.Lib.Abstractions.Modules;
using Alfateam.Messenger.Lib.Enums;
using Alfateam.Messenger.Models.Abstractions.Chats;
using Alfateam.Messenger.Models.Chats;
using Alfateam.Messenger.Models.DTO.Abstractions.Chats;
using Alfateam.Messenger.Models.DTO.Chats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TdLib;
using static TdLib.TdApi.ChatType;

namespace Alfateam.Messenger.Lib.Modules.Telegram
{
    public class TelegramChatsModule : ChatsModule
    {

        private TelegramMessenger Messenger;
        public TelegramChatsModule(TelegramMessenger messenger)
        {
            Messenger = messenger;
        }

        public override async Task<Chat> CreateChat(Chat chat)
        {
            if(chat is ExternalPrivateChat privateChat)
            {
                var createdChat = await Messenger.Client.CreatePrivateChatAsync(userId: Convert.ToInt64(privateChat.PeerId));
                privateChat.ChatId = createdChat.Id.ToString();
            }
            else if (chat is ExternalGroupChat groupChat)
            {
                var createdChat = await Messenger.Client.CreateNewBasicGroupChatAsync(title: groupChat.Title);
                groupChat.ChatId = createdChat.ChatId.ToString();
            }

            return chat;
        }
        public override async Task<Chat> EditChat(Chat chat)
        {
            throw new NotImplementedException();
        }

        public override async Task<ChatDeletionResult> DeleteChat(string chatId)
        {
            var response = await Messenger.Client.DeleteChatAsync(chatId: Convert.ToInt64(chatId));

            throw new NotImplementedException();
        }
        public override async Task<Chat> GetChat(string chatId)
        {
            var foundChat = await Messenger.Client.GetChatAsync(chatId: Convert.ToInt64(chatId));
            if(foundChat != null)
            {
                return await TransformTgChatToUniversal(foundChat);
            }
            return null;
        }
        public override async Task<IEnumerable<Chat>> GetChats(int offset, int count)
        {
            var chatsResponse = await Messenger.Client.GetChatsAsync(limit: int.MaxValue);

            var tgChats = new List<TdApi.Chat>();
            foreach(var chatId in chatsResponse.ChatIds)
            {
                tgChats.Add(await Messenger.Client.GetChatAsync(chatId));
            }


            var universalChats = new List<Chat>();
            foreach(var tgChat in tgChats)
            {
                universalChats.Add(await TransformTgChatToUniversal(tgChat));
            }

            return universalChats;
        }








        private async Task<Chat> TransformTgChatToUniversal(TdApi.Chat tgChat)
        {
            if(tgChat.Type is ChatTypePrivate tgPrivateChat)
            {
                return new ExternalPrivateChat
                {
                    PeerId = tgPrivateChat.UserId.ToString(),
                    OurUserId = await Messenger.Auth.GetOurUserId(),
                };
            }
            if (tgChat.Type is ChatTypeSecret tgSecretChat)
            {
                return new ExternalPrivateChat
                {
                    PeerId = tgSecretChat.UserId.ToString(),
                    ChatId = tgSecretChat.SecretChatId.ToString(),
                    OurUserId = await Messenger.Auth.GetOurUserId(),
                };
            }
            else if (tgChat.Type is ChatTypeBasicGroup tgGroupChat)
            {
                var tgGroupFullInfo = await Messenger.Client.GetBasicGroupFullInfoAsync(tgGroupChat.BasicGroupId);

                string chatPhotoPath = "";
                if (tgGroupFullInfo.Photo.Sizes.Any())
                {
                    chatPhotoPath = tgGroupFullInfo.Photo.Sizes[0].Photo.Remote.UniqueId;
                }

                return new ExternalGroupChat
                {
                    Title = tgGroupFullInfo.Description,
                    ChatPhotoPath= chatPhotoPath
                };
            }
            else if(tgChat.Type is ChatTypeSupergroup tgSupergroupChat)
            {
                var tgGroupFullInfo = await Messenger.Client.GetSupergroupFullInfoAsync(tgSupergroupChat.SupergroupId);

                string chatPhotoPath = "";
                if (tgGroupFullInfo.Photo.Sizes.Any())
                {
                    chatPhotoPath = tgGroupFullInfo.Photo.Sizes[0].Photo.Remote.UniqueId;
                }

                return new ExternalGroupChat
                {
                    Title = tgGroupFullInfo.Description,
                    ChatPhotoPath = chatPhotoPath
                };
            }

            throw new NotImplementedException("Какой то другой тип чата тг");
        }

    }
}
