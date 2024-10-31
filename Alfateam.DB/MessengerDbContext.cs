using Alfateam.Messenger.Models;
using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.Abstractions.Attachments;
using Alfateam.Messenger.Models.Abstractions.Chats;
using Alfateam.Messenger.Models.Abstractions.Messages;
using Alfateam.Messenger.Models.General;
using Alfateam.Messenger.Models.General.Chats;
using Alfateam.Messenger.Models.General.GroupChats;
using Alfateam.Messenger.Models.General.Security;
using Alfateam.Messenger.Models.Stickers.Alfateam;
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

        public DbSet<MessageAttachment> Attachments { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }


        public DbSet<AbsSticker> Stickers { get; set; }
        public DbSet<AbsStickerSet> StickersSets { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<OfflineAutoMessageSendTime> OfflineAutoMessageSendTimes { get; set; }

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
        public DbSet<GroupChatMember> GroupChatMembers { get; set; }
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
    }
}
