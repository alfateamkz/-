using Alfateam.DB.Helpers;
using Alfateam.EDM.Models.Abstractions.ApprovalRoutes;
using Alfateam.EDM.Models.ApprovalRoutes.AfterDocSigning;
using Alfateam.Messenger.Models;
using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.Abstractions.Messages;
using Alfateam.Messenger.Models.Accounts;
using Alfateam.Messenger.Models.Accounts.Messengers;
using Alfateam.Messenger.Models.Accounts.SocialNetworks;
using Alfateam.Messenger.Models.Chats;
using Alfateam.Messenger.Models.General;
using Alfateam.Messenger.Models.General.Chats;
using Alfateam.Messenger.Models.General.Chats.OfflineAutoTime;
using Alfateam.Messenger.Models.General.GroupChats;
using Alfateam.Messenger.Models.General.GroupChats.Members;
using Alfateam.Messenger.Models.General.Security;
using Alfateam.Messenger.Models.Integrations.API;
using Alfateam.Messenger.Models.Integrations.ExtMessenger;
using Alfateam.Messenger.Models.MessageAttachments;
using Alfateam.Messenger.Models.Messages.SystemMessages;
using Alfateam.Messenger.Models.Messages.UserMessages;
using Alfateam.Messenger.Models.Peers;
using Alfateam.Messenger.Models.Stickers.Alfateam;
using Alfateam.Messenger.Models.Stickers.External;
using Alfateam.Messenger.Models.StickerSets;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.DB
{
    public class MessengerDbContext : DbContext
    {
        public MessengerDbContext()
        {
            Database.EnsureCreated();
            CreateDefaultEntities();
        }
        public MessengerDbContext(DbContextOptions<MessengerDbContext> options)
        {
            Database.EnsureCreated();
            CreateDefaultEntities();
        }

        #region Abstractions
        public DbSet<MessageBase> Messages { get; set; }
        public DbSet<AbsSticker> Stickers { get; set; }
        public DbSet<AbsStickerSet> StickersSets { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<ChatBase> Chats { get; set; }
        public DbSet<GroupChatMemberBase> GroupChatMembers { get; set; }
        public DbSet<MessageAttachmentBase> Attachments { get; set; }
        public DbSet<OfflineAutoMessageSendTime> OfflineAutoMessageSendTimes { get; set; }
        public DbSet<Peer> Peers { get; set; }

        #endregion

        #region General

        #region Chats

        public DbSet<ChatFolder> ChatFolders { get; set; }
        public DbSet<ChatMessageDeletedInfo> ChatMessageDeletedInfos { get; set; }
        public DbSet<ChatNotificationSettings> ChatNotificationSettings { get; set; }
        public DbSet<ChatPersonalSettings> ChatPersonalSettings { get; set; }
        public DbSet<HelloAutoMessageSettings> HelloAutoMessageSettings { get; set; }
        public DbSet<OfflineAutoMessageSettings> OfflineAutoMessageSettings { get; set; }
        public DbSet<QuickAnswer> QuickAnswers { get; set; }
        public DbSet<SendByScheduleDayOfWeek> SendByScheduleDayOfWeeks { get; set; }

        #endregion

        #region GroupChats
        public DbSet<GroupChatMemberPermissions> GroupChatMemberPermissions { get; set; }

        #endregion

        #region Security

        public DbSet<AllowedAccountsAccess> AllowedAccountsAccesses { get; set; }
        public DbSet<TrustedUserIPAddress> TrustedUserIPAddresses { get; set; }
        public DbSet<UserPermissions> UserPermissions { get; set; }
        #endregion

        public DbSet<Business> Businesses { get; set; }
        public DbSet<CompanyWorkSpace> CompanyWorkSpaces { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<SubscriptionInfo> SubscriptionInfos { get; set; }
        public DbSet<User> Users { get; set; }

        #endregion

        #region Integrations

        #region API

        public DbSet<AlfateamAPIKey> AlfateamAPIKeys { get; set; }
        public DbSet<AlfateamAPIRequestEntry> AlfateamAPIRequestEntries { get; set; }

        #endregion

        #region ExtMessenger
        public DbSet<ExtMessengerIntegration> ExtMessengerIntegrations { get; set; }
        public DbSet<ExtMessengerUser> ExtMessengerUsers { get; set; }

        #endregion

        #endregion

        public DbSet<ChatBackground> ChatBackgrounds { get; set; }
        public DbSet<ChatNotificationSound> ChatNotificationSounds { get; set; }






        private void CreateDefaultEntities()
        {
            CreateDefaultChatBackgrounds();
            CreateDefaultChatNotificationSounds();
        }

        private void CreateDefaultChatBackgrounds()
        {
            if(!ChatBackgrounds.Any(o => o.AccountId == null))
            {
                ChatBackgrounds.Add(new ChatBackground
                {
                    Filepath = ""
                });
                ChatBackgrounds.Add(new ChatBackground
                {
                    Filepath = ""
                });
                ChatBackgrounds.Add(new ChatBackground
                {
                    Filepath = ""
                });
                ChatBackgrounds.Add(new ChatBackground
                {
                    Filepath = ""
                });
                ChatBackgrounds.Add(new ChatBackground
                {
                    Filepath = ""
                });

                SaveChanges();
            }      
        }
        private void CreateDefaultChatNotificationSounds()
        {
            if (!ChatNotificationSounds.Any(o => o.AccountId == null))
            {
                ChatNotificationSounds.Add(new ChatNotificationSound
                {
                    Filepath = ""
                });
                ChatNotificationSounds.Add(new ChatNotificationSound
                {
                    Filepath = ""
                });
                ChatNotificationSounds.Add(new ChatNotificationSound
                {
                    Filepath = ""
                });
                ChatNotificationSounds.Add(new ChatNotificationSound
                {
                    Filepath = ""
                });
                ChatNotificationSounds.Add(new ChatNotificationSound
                {
                    Filepath = ""
                });

                SaveChanges();
            }
        }





        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(ConnectionStrings.BuildConnectionString("messengerDb"), new MySqlServerVersion(new Version(8, 0, 11)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Abstract MessageBase
            modelBuilder.Entity<MessageBase>().HasDiscriminator(b => b.Discriminator);
            modelBuilder.Entity<ChatPhotoChangedMessage>();
            modelBuilder.Entity<ChatTitleChangedMessage>();
            modelBuilder.Entity<GroupChatCreatedMessage>();
            modelBuilder.Entity<JoinedUserMessage>();
            modelBuilder.Entity<KickedUserMessage>();
            modelBuilder.Entity<PinnedSystemMessage>();

            modelBuilder.Entity<ContactMessage>();
            modelBuilder.Entity<LocationMessage>();
            modelBuilder.Entity<StickerMessage>();
            modelBuilder.Entity<TextMessage>();
            modelBuilder.Entity<VoiceMessage>();

            //Abstract AbsSticker
            modelBuilder.Entity<AbsSticker>().HasDiscriminator(b => b.Discriminator);
            modelBuilder.Entity<AlfateamSticker>();
            modelBuilder.Entity<ExternalSticker>();

            //Abstract AbsStickerSet
            modelBuilder.Entity<AbsStickerSet>().HasDiscriminator(b => b.Discriminator);
            modelBuilder.Entity<AlfateamStickersSet>();
            modelBuilder.Entity<ExternalStickersSet>();

            //Abstract Account
            modelBuilder.Entity<Account>().HasDiscriminator(b => b.Discriminator);
            modelBuilder.Entity<TelegramAccount>();
            modelBuilder.Entity<ViberAccount>();
            modelBuilder.Entity<WhatsAppAccount>();
            modelBuilder.Entity<FacebookAccount>();
            modelBuilder.Entity<InstagramAccount>();
            modelBuilder.Entity<VKAccount>();
            modelBuilder.Entity<EmailAccount>();

            //Abstract ChatBase
            modelBuilder.Entity<ChatBase>().HasDiscriminator(b => b.Discriminator);
            modelBuilder.Entity<GroupChat>();
            modelBuilder.Entity<PrivateChat>();

            //Abstract GroupChatMemberBase
            modelBuilder.Entity<GroupChatMemberBase>().HasDiscriminator(b => b.Discriminator);
            modelBuilder.Entity<AlfateamGroupChatMember>();
            modelBuilder.Entity<ExtGroupChatMember>();

            //Abstract MessageAttachmentBase
            modelBuilder.Entity<MessageAttachmentBase>().HasDiscriminator(b => b.Discriminator);
            modelBuilder.Entity<FileMessageAttachment>();
            modelBuilder.Entity<URLMessageAttachment>();

            //Abstract OfflineAutoMessageSendTime
            modelBuilder.Entity<OfflineAutoMessageSendTime>().HasDiscriminator(b => b.Discriminator);
            modelBuilder.Entity<OfflineAutoMessageSendAlways>();
            modelBuilder.Entity<OfflineAutoMessageSendBySchedule>();

            //Abstract Peer
            modelBuilder.Entity<Peer>().HasDiscriminator(b => b.Discriminator);
            modelBuilder.Entity<AlfateamExtMessengerPeer>();
            modelBuilder.Entity<AlfateamMessengerPeer>();
            modelBuilder.Entity<ExtMessengerPeer>();
        }
    }
}
