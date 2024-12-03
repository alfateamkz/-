using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.Accounts.Messengers;
using Alfateam.Messenger.Models.Accounts.SocialNetworks;
using Alfateam.Messenger.Models.Accounts;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alfateam.Messenger.Models.DTO.Accounts.Messengers;
using Alfateam.Messenger.Models.DTO.Accounts.SocialNetworks;
using Alfateam.Messenger.Models.DTO.Accounts;
using Newtonsoft.Json;

namespace Alfateam.Messenger.Models.DTO.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<AccountDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(TelegramAccountDTO), "TelegramAccount")]
    [JsonKnownType(typeof(ViberAccountDTO), "ViberAccount")]
    [JsonKnownType(typeof(WhatsAppAccountDTO), "WhatsAppAccount")]
    [JsonKnownType(typeof(FacebookAccountDTO), "FacebookAccount")]
    [JsonKnownType(typeof(InstagramAccountDTO), "InstagramAccount")]
    [JsonKnownType(typeof(VKAccountDTO), "VKAccount")]
    [JsonKnownType(typeof(AlfateamMessengerAccountDTO), "AlfateamMessengerAccount")]
    [JsonKnownType(typeof(EmailAccountDTO), "EmailAccount")]
    public class AccountDTO : DTOModelAbs<MessengerMailingAccount>
    {
        public string Title { get; set; }
        public string? Description { get; set; }


        public string Login { get; set; }
        public string Password { get; set; }
    }
}
