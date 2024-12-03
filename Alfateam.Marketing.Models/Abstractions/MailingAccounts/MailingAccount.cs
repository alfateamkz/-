using Alfateam.Core;
using Alfateam.Marketing.Models.ExternalInteractions;
using Alfateam.Marketing.Models.MailingAccounts;
using Alfateam.Marketing.Models.MailingAccounts.Messengers;
using Alfateam.Marketing.Models.MailingAccounts.Social;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Abstractions.MailingAccounts
{


    [JsonConverter(typeof(JsonKnownTypesConverter<MailingAccount>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(TelegramMailingAccount), "TelegramMailingAccount")]
    [JsonKnownType(typeof(ViberMailingAccount), "ViberMailingAccount")]
    [JsonKnownType(typeof(WhatsAppMailingAccount), "WhatsAppMailingAccount")]

    [JsonKnownType(typeof(FacebookMailingAccount), "FacebookMailingAccount")]
    [JsonKnownType(typeof(InstagramMailingAccount), "InstagramMailingAccount")]
    [JsonKnownType(typeof(VKMailingAccount), "VKMailingAccount")]

    [JsonKnownType(typeof(EmailMailingAccount), "EmailMailingAccount")]
    public class MailingAccount : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }



        public string Title { get; set; }
        public string? Description { get; set; }


        public string Login { get; set; }
        public string Password { get; set; }




        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int BusinessCompanyId { get; set; }
    }
}
