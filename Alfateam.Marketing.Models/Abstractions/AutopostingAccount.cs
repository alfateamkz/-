using Alfateam.Core;
using Alfateam.Marketing.Models.Ads.Accounts;
using Alfateam.Marketing.Models.Autoposting.Accounts.Messengers;
using Alfateam.Marketing.Models.Autoposting.Accounts.Resources;
using Alfateam.Marketing.Models.Autoposting.Accounts.Social;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<AdsServiceAccount>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(TelegramAutopostingAccount), "TelegramAutopostingAccount")]

    [JsonKnownType(typeof(PikabuAutopostingAccount), "PikabuAutopostingAccount")]
    [JsonKnownType(typeof(VC_RUAutopostingAccount), "VC_RUAutopostingAccount")]
    [JsonKnownType(typeof(YandexZenAutopostingAccount), "YandexZenAutopostingAccount")]

    [JsonKnownType(typeof(FacebookAutopostingAccount), "FacebookAutopostingAccount")]
    [JsonKnownType(typeof(InstagramAutopostingAccount), "InstagramAutopostingAccount")]
    [JsonKnownType(typeof(VKAutopostingAccount), "VKAutopostingAccount")]
    public class AutopostingAccount : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }
    }
}
