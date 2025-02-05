using Alfateam.Core.Exceptions;
using Alfateam.Core.Services;
using Alfateam.DB;
using Alfateam.Messenger.API.Enums;
using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.Abstractions.Messages;
using Alfateam.Messenger.Models.Chats;
using Alfateam.Messenger.Models.Enums;
using Alfateam.Messenger.Models.General.GroupChats.Members;
using Alfateam.Messenger.Models.General.GroupChats;
using Alfateam.Messenger.Models.Messages.SystemMessages;
using Alfateam.Messenger.Models.Messages.UserMessages;
using Alfateam.Messenger.Models.Peers;
using Microsoft.EntityFrameworkCore;
using Alfateam.Messenger.Models.DTO.Abstractions;
using InstagramApiSharp.Classes;
using Alfateam.Messenger.Models.Stickers.Alfateam;
using Alfateam.Messenger.Models.General;
using NAudio.Wave;

namespace Alfateam.Messenger.API.Services
{
    public class AlfateamMessengerService
    {
        private readonly MessengerDbContext DB;
        private readonly AbsDBService DBService;
        private readonly AbsFilesService FilesService;
        public AlfateamMessengerService(MessengerDbContext db, AbsDBService dbService, AbsFilesService filesService)
        {
            DB = db;
            DBService = dbService;
            FilesService = filesService;
        }

        #region Chats
        public IEnumerable<ChatBase> GetAvailableAlfateamChats(int authorizedUserId)
        {
            var myPeers = DB.Peers.Cast<AlfateamMessengerPeer>().Where(o => o.Id == authorizedUserId);
            return GetChatsImpl(myPeers);
        }
        public IEnumerable<ChatBase> GetAvailableAlfateamExtMessengerChats(int userId)
        {
            var myPeers = DB.Peers.Cast<AlfateamExtMessengerPeer>().Where(o => o.User.Id == userId);
            return GetChatsImpl(myPeers);
        }



        public IEnumerable<int> GetAlfateamChatMembersIds(int chatId, int authorizedUserId)
        {
            var chat = DBService.TryGetOne(GetAvailableAlfateamChats(authorizedUserId), chatId);
            if (chat is PrivateChat privateChat)
            {
                return new List<int>() 
                { 
                    (privateChat.CreatedBy as AlfateamMessengerPeer).UserId, 
                    (privateChat.Receiver as AlfateamMessengerPeer).UserId 
                };
            }
            else if(chat is GroupChat groupChat)
            {
                var members = DB.GroupChatMembers.Cast<AlfateamGroupChatMember>()
                                                 .Where(o => o.GroupChatId == chatId && !o.IsKicked);

                return members.Select(o => o.Peer as AlfateamMessengerPeer).Select(o => o.UserId);
            }
            throw new NotImplementedException();
        }
        public IEnumerable<int> GetAlfateamExtMessengerChatMembersIds(int chatId, int authorizedUserId)
        {
            var chat = DBService.TryGetOne(GetAvailableAlfateamExtMessengerChats(authorizedUserId), chatId);
            if (chat is PrivateChat privateChat)
            {
                return new List<int>()
                {
                    (privateChat.CreatedBy as AlfateamExtMessengerPeer).UserId,
                    (privateChat.Receiver as AlfateamExtMessengerPeer).UserId
                };
            }
            else if (chat is GroupChat groupChat)
            {
                var members = DB.GroupChatMembers.Cast<AlfateamGroupChatMember>()
                                                 .Where(o => o.GroupChatId == chatId && !o.IsKicked);

                return members.Select(o => o.Peer as AlfateamExtMessengerPeer).Select(o => o.UserId);
            }
            throw new NotImplementedException();
        }





        public void ThrowIfAlfateamChatNotExistOrAvailable(int chatId, int authorizedUserId)
        {
            DBService.TryGetOne(GetAvailableAlfateamChats(authorizedUserId), chatId);
        }
        public void ThrowIfAlfateamExtChatNotExistOrAvailable(int chatId, int authorizedUserId)
        {
            DBService.TryGetOne(GetAvailableAlfateamExtMessengerChats(authorizedUserId), chatId);
        }




        public ChatBase TryCreateChat(int authorizedUserId, AlfateamMessengerType type, ChatBaseDTO model)
        {
            ChatBase foundChat = null;
            switch (type)
            {
                case AlfateamMessengerType.Internal:
                    foundChat = GetPrivateChatByPeerType<AlfateamMessengerPeer>(authorizedUserId, type);
                    break;
                case AlfateamMessengerType.ExtIntegration:
                    foundChat = GetPrivateChatByPeerType<AlfateamExtMessengerPeer>(authorizedUserId, type);
                    break;
            }


            if (foundChat != null)
            {
                throw new Exception400($"Чат с данным пользователем уже существует. Id чата для получения {foundChat.Id}");
            }
            if (!model.IsValid())
            {
                throw new Exception400($"Проверьте корректность заполнения полей");
            }


            var newChat = model.CreateDBModelFromDTO();
            if (newChat is PrivateChat privateChat)
            {
                privateChat.CreatedById = authorizedUserId;
            }
            else if (newChat is GroupChat groupChat)
            {
                groupChat.Members.Add(new AlfateamGroupChatMember
                {
                    Peer = CreatePeer(authorizedUserId, type),
                    Role = GroupChatMemberRole.Owner,
                    Permissions = new GroupChatMemberPermissions()
                });
            }

            return newChat;

        }

        #endregion

        #region Messages
        public IEnumerable<MessageBase> GetAvailableAlfateamChatMessages(int chatId, int authorizedUserId)
        {
            ThrowIfAlfateamChatNotExistOrAvailable(chatId, authorizedUserId);

            var messages = DB.Messages.Include(o => o.DeletedInfo)
                                      .Where(o => o.ChatBaseId == chatId
                                               && !o.IsDeleted
                                               && (o.DeletedInfo == null || (o.DeletedInfo.PeerBy is AlfateamMessengerPeer 
                                                                         && (o.DeletedInfo.PeerBy as AlfateamMessengerPeer).UserId == authorizedUserId 
                                                                         && !o.DeletedInfo.MessageDeletedForAll)));


            foreach (var message in messages)
            {
                IncludeMessageFields(message);
            }

            return messages;
        }
        public IEnumerable<MessageBase> GetAvailableAlfateamExtMessengerChatMessages(int chatId, int authorizedUserId)
        {
            ThrowIfAlfateamExtChatNotExistOrAvailable(chatId, authorizedUserId);

            var messages = DB.Messages.Include(o => o.DeletedInfo)
                                  .Where(o => o.ChatBaseId == chatId
                                           && !o.IsDeleted
                                           && (o.DeletedInfo == null || (o.DeletedInfo.PeerBy is AlfateamExtMessengerPeer
                                                                     && (o.DeletedInfo.PeerBy as AlfateamExtMessengerPeer).UserId == authorizedUserId
                                                                     && !o.DeletedInfo.MessageDeletedForAll)));


            foreach (var message in messages)
            {
                IncludeMessageFields(message);
            }

            return messages;
        }



        public MessageBase TrySendTextMessage(AlfateamMessengerType type, int chatId, int authorizedUserId, string message, List<MessageAttachmentBase> attachments)
        {
            this.ThrowIfAlfateamChatNotExistOrAvailable(chatId, authorizedUserId);
       
            var createdMessage = new TextMessage
            {
                Text = message,
                ChatBaseId = chatId,
                Attachments = attachments,
                SentBy = CreatePeer(authorizedUserId, type),
            };
            DBService.CreateEntity(DB.Messages, createdMessage);
            return createdMessage;
        }
        public MessageBase TrySendStickerMessage(AlfateamMessengerType type, int chatId, int authorizedUserId, int stickerId)
        {
            this.ThrowIfAlfateamChatNotExistOrAvailable(chatId, authorizedUserId);

            var createdMessage = new StickerMessage
            {
                ChatBaseId = chatId,
                SentBy = CreatePeer(authorizedUserId, type),
                Sticker = DBService.TryGetOne(DB.Stickers.Cast<AlfateamSticker>(), Convert.ToInt32(stickerId))
            };
            DBService.CreateEntity(DB.Messages, createdMessage);
            return createdMessage;
        }

        public MessageBase TrySendVoiceMessage(AlfateamMessengerType type, int chatId, int authorizedUserId, byte[] message)
        {
            this.ThrowIfAlfateamChatNotExistOrAvailable(chatId, authorizedUserId);

            var createdMessage = new VoiceMessage
            {
                ChatBaseId = chatId,
                SentBy = CreatePeer(authorizedUserId, type),
                Duration = default(TimeSpan), //TODO: VoiceMessage Duration
                MessageFilePath = FilesService.UploadFile(message, ".ogg"),
                Waveform = "",//TODO: VoiceMessage Waveform
            };
            DBService.CreateEntity(DB.Messages, createdMessage);
            return createdMessage;
        }





        public MessageBase TryEditTextMessage(AlfateamMessengerType type, int chatId, int authorizedUserId, int messageId, string message)
        {
            MessageBase editedMessage = null;
            switch (type)
            {
                case AlfateamMessengerType.Internal:
                    editedMessage = DBService.TryGetOne(this.GetAvailableAlfateamChatMessages(Convert.ToInt32(chatId), authorizedUserId), messageId); 
                    break;
                case AlfateamMessengerType.ExtIntegration:
                    editedMessage = DBService.TryGetOne(this.GetAvailableAlfateamExtMessengerChatMessages(Convert.ToInt32(chatId), authorizedUserId), messageId);
                    break;
            }

            if (editedMessage is not TextMessage)
            {
                throw new Exception400("Редактировать можно только текстовое сообщение");
            }

            (editedMessage as TextMessage).Text = message;
            DBService.UpdateEntity(DB.Messages, editedMessage);
            return editedMessage;
        }





        public bool TryDeleteMessage(AlfateamMessengerType type, int chatId, int authorizedUserId, int messageId, bool forAll)
        {
            MessageBase message = null;
            switch (type)
            {
                case AlfateamMessengerType.Internal:
                    message = DBService.TryGetOne(this.GetAvailableAlfateamChatMessages(chatId, authorizedUserId), messageId);
                    break;
                case AlfateamMessengerType.ExtIntegration:
                    message = DBService.TryGetOne(this.GetAvailableAlfateamExtMessengerChatMessages(chatId, authorizedUserId), messageId);
                    break;
            }

             
            if (message.SentAt.AddHours(1) < DateTime.UtcNow && forAll)
            {
                throw new Exception400("Сообщение нельзя удалить для всех, т.к. срок отправки более часа назад");
            }

            message.DeletedInfo = new Messenger.Models.General.Chats.ChatMessageDeletedInfo
            {
                MessageDeletedForAll = forAll,
                PeerBy = CreatePeer(authorizedUserId, type)
            };
            DBService.UpdateEntity(DB.Messages, message);

            return true;
        }
     

        #endregion










        #region Private get chats methods

        private IEnumerable<ChatBase> GetChatsImpl(IQueryable<Peer> myPeers)
        {
            List<ChatBase> chats = new List<ChatBase>();
            AddPrivateChats(chats, myPeers);
            AddGroupChats(chats, myPeers);

            return chats;
        }
        private void AddPrivateChats(List<ChatBase> chats, IQueryable<Peer> myPeers)
        {

            var privateChatIds = myPeers.Where(o => o.PrivateChatId != null)
                                        .Select(o => o.PrivateChatId)
                                        .Distinct();
            foreach (var chatId in privateChatIds)
            {
                var chat = DB.Chats.Cast<PrivateChat>()
                                   .Include(o => o.Receiver)
                                   .Include(o => o.CreatedBy)
                                   .FirstOrDefault(o => o.Id == chatId);
                chats.Add(chat);
            }
        }
        private void AddGroupChats(List<ChatBase> chats, IQueryable<Peer> myPeers)
        {
            var groupChatMemberIds = myPeers.Where(o => o.AlfateamGroupChatMemberId != null)
                                            .Select(o => o.AlfateamGroupChatMemberId)
                                            .Distinct();
            foreach (int memberId in groupChatMemberIds)
            {
                int groupChatId = DB.GroupChatMembers.FirstOrDefault(o => o.Id == memberId).GroupChatId;
                var chat = DB.Chats.Cast<GroupChat>().FirstOrDefault(o => o.Id == groupChatId);
                chats.Add(chat);
            }
        }



        private ChatBase GetPrivateChatByPeerType<T>(int authorizedUserId, AlfateamMessengerType type) where T : Peer
        {
            return this.GetAvailableAlfateamChats(authorizedUserId)
                       .Cast<PrivateChat>()
                       .Where(o => o.CreatedBy is T && o.Receiver is T)
                       .FirstOrDefault(o => o.CreatedBy.GetPeerUserId() == authorizedUserId.ToString() || o.Receiver.GetPeerUserId() == authorizedUserId.ToString());
        }

        #endregion

        #region Private messages methods

        private void IncludeMessageFields(MessageBase message)
        {
            if (message is GroupChatCreatedMessage groupChatCreatedMessage)
            {
                groupChatCreatedMessage.CreatedBy = DB.Peers.FirstOrDefault(o => o.Id == groupChatCreatedMessage.CreatedById);
            }
            else if (message is JoinedUserMessage joinedUserMessage)
            {
                joinedUserMessage.Peer = DB.Peers.FirstOrDefault(o => o.Id == joinedUserMessage.PeerId);
            }
            else if (message is KickedUserMessage kickedUserMessage)
            {
                kickedUserMessage.KickedBy = DB.Peers.FirstOrDefault(o => o.Id == kickedUserMessage.KickedById);
                kickedUserMessage.KickedPeer = DB.Peers.FirstOrDefault(o => o.Id == kickedUserMessage.KickedPeerId);
            }
            else if (message is PinnedSystemMessage pinnedSystemMessage)
            {
                pinnedSystemMessage.Message = DB.Messages.FirstOrDefault(o => o.Id == pinnedSystemMessage.MessageId);
                IncludeMessageFields(pinnedSystemMessage.Message);
            }
            else if (message is ContactMessage contactMessage)
            {
                contactMessage.ContactOf = DB.Peers.FirstOrDefault(o => o.Id == contactMessage.ContactOfId);
            }
            else if (message is StickerMessage stickerMessage)
            {
                stickerMessage.Sticker = DB.Stickers.FirstOrDefault(o => o.Id == stickerMessage.StickerId);
            }
            else if (message is TextMessage textMessage)
            {
                textMessage.Attachments = DB.Attachments.Where(o => o.TextMessageId == textMessage.Id).ToList();
            }
        }

        #endregion

        private Peer CreatePeer(int userId, AlfateamMessengerType type)
        {
            if (type == AlfateamMessengerType.Internal)
            {
                return new AlfateamMessengerPeer
                {
                    UserId = userId,
                };
            }
            else if (type == AlfateamMessengerType.ExtIntegration)
            {
                return new AlfateamExtMessengerPeer
                {
                    UserId = userId,
                };
            }
            throw new NotImplementedException("CreatePeer");
        }
    }
}
