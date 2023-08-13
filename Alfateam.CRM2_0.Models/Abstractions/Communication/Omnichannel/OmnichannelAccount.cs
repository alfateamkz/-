using Alfateam.CRM2_0.Models.Abstractions.Communication.Messenger;
using Alfateam.CRM2_0.Models.Communication.Messenger.Messages;
using Alfateam.CRM2_0.Models.Communication.Omnichannel.Accounts;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Abstractions.Communication.Omnichannel
{

    [JsonConverter(typeof(JsonKnownTypesConverter<OmnichannelAccount>))]
    [JsonDiscriminator(Name = "Discriminator")]
    [JsonKnownType(typeof(EmailAccount), "EmailAccount")]
    [JsonKnownType(typeof(InstagramAccount), "InstagramAccount")]
    [JsonKnownType(typeof(TelegramAccount), "TelegramAccount")]
    [JsonKnownType(typeof(VkontakteAccount), "VkontakteAccount")]
    [JsonKnownType(typeof(WhatsAppAccount), "WhatsAppAccount")]
    /// <summary>
    /// Модель аккаунта в системе омниканальности
    /// </summary>
    public abstract class OmnichannelAccount : AbsModel
    {
    }
}
