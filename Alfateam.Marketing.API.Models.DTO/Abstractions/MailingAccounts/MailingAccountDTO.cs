using Alfateam.Marketing.Models.Abstractions.MailingAccounts;
using Alfateam.Marketing.Models.MailingAccounts.Messengers;
using Alfateam.Marketing.Models.MailingAccounts.Social;
using Alfateam.Marketing.Models.MailingAccounts;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;
using Alfateam.Marketing.API.Models.DTO.MailingAccounts.Messengers;
using Alfateam.Marketing.API.Models.DTO.MailingAccounts.Social;
using Alfateam.Marketing.API.Models.DTO.MailingAccounts;

namespace Alfateam.Marketing.API.Models.DTO.Abstractions.MailingAccounts
{
    [JsonConverter(typeof(JsonKnownTypesConverter<MailingAccountDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(TelegramMailingAccountDTO), "TelegramMailingAccount")]
    [JsonKnownType(typeof(ViberMailingAccountDTO), "ViberMailingAccount")]
    [JsonKnownType(typeof(WhatsAppMailingAccountDTO), "WhatsAppMailingAccount")]

    [JsonKnownType(typeof(FacebookMailingAccountDTO), "FacebookMailingAccount")]
    [JsonKnownType(typeof(InstagramMailingAccountDTO), "InstagramMailingAccount")]
    [JsonKnownType(typeof(VKMailingAccountDTO), "VKMailingAccount")]

    [JsonKnownType(typeof(EmailMailingAccountDTO), "EmailMailingAccount")]
    public class MailingAccountDTO : DTOModelAbs<MailingAccount>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }



        public string Title { get; set; }
        public string? Description { get; set; }


        public string Login { get; set; }
        public string Password { get; set; }
    }
}
