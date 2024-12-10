﻿using Alfateam.Marketing.API.Models.DTO.Autoposting.Accounts.Messengers;
using Alfateam.Marketing.API.Models.DTO.Autoposting.Accounts.Resources;
using Alfateam.Marketing.API.Models.DTO.Autoposting.Accounts.Social;
using Alfateam.Marketing.Models.Abstractions;
using Alfateam.Marketing.Models.Autoposting.Accounts.Messengers;
using Alfateam.Marketing.Models.Autoposting.Accounts.Resources;
using Alfateam.Marketing.Models.Autoposting.Accounts.Social;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;

namespace Alfateam.Marketing.API.Models.DTO.Abstractions
{

    [JsonConverter(typeof(JsonKnownTypesConverter<AutopostingAccountDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(TelegramAutopostingAccountDTO), "TelegramAutopostingAccount")]

    [JsonKnownType(typeof(PikabuAutopostingAccountDTO), "PikabuAutopostingAccount")]
    [JsonKnownType(typeof(VC_RUAutopostingAccountDTO), "VC_RUAutopostingAccount")]
    [JsonKnownType(typeof(YandexZenAutopostingAccountDTO), "YandexZenAutopostingAccount")]

    [JsonKnownType(typeof(FacebookAutopostingAccountDTO), "FacebookAutopostingAccount")]
    [JsonKnownType(typeof(InstagramAutopostingAccountDTO), "InstagramAutopostingAccount")]
    [JsonKnownType(typeof(VKAutopostingAccountDTO), "VKAutopostingAccount")]
    public class AutopostingAccountDTO : DTOModelAbs<AutopostingAccount>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }
    }
}
