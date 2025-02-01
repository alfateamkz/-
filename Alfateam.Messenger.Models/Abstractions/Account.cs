using Alfateam.Core;
using Alfateam.Messenger.Models.Accounts;
using Alfateam.Messenger.Models.Accounts.Messengers;
using Alfateam.Messenger.Models.Accounts.SocialNetworks;
using Alfateam.Messenger.Models.General.Chats;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Abstractions
{
    /// <summary>
    /// Модель аккаунта в соц.сети\мессенджере\эл.почте
    /// </summary>
    [JsonConverter(typeof(JsonKnownTypesConverter<Account>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(TelegramAccount), "TelegramAccount")]
    [JsonKnownType(typeof(ViberAccount), "ViberAccount")]
    [JsonKnownType(typeof(WhatsAppAccount), "WhatsAppAccount")]
    [JsonKnownType(typeof(FacebookAccount), "FacebookAccount")]
    [JsonKnownType(typeof(InstagramAccount), "InstagramAccount")]
    [JsonKnownType(typeof(VKAccount), "VKAccount")]
    [JsonKnownType(typeof(EmailAccount), "EmailAccount")]
    public class Account : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }



        public string Title { get; set; }
        public string? Description { get; set; }


        public string Login { get; set; }
        public string Password { get; set; }



        public List<ChatBase> Chats { get; set; } = new List<ChatBase>();



        public List<ChatFolder> Folders { get; set; } = new List<ChatFolder>();
        public List<QuickAnswer> QuickAnswers { get; set; } = new List<QuickAnswer>();
        public List<ChatBackground> CustomChatBackgrounds { get; set; } = new List<ChatBackground>();


        public HelloAutoMessageSettings HelloAutoMessageSettings { get; set; }
        public OfflineAutoMessageSettings OfflineAutoMessageSettings { get; set; }



        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int CompanyWorkSpaceId { get; set; }
    }
}
