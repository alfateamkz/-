using Alfateam.Core;
using Alfateam.Marketing.Models.Ads.Accounts;
using Alfateam.Marketing.Models.SalesGenerators.StartOptions;
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
    [JsonKnownType(typeof(FacebookAdsServiceAccount), "FacebookAdsServiceAccount")]
    [JsonKnownType(typeof(GoogleAdsAdsServiceAccount), "GoogleAdsAdsServiceAccount")]
    [JsonKnownType(typeof(VKAdsServiceAccount), "VKAdsServiceAccount")]
    [JsonKnownType(typeof(YandexDirectAdsServiceAccount), "YandexDirectAdsServiceAccount")]
    public class AdsServiceAccount : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        public string Title { get; set; }


        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int BusinessCompanyId { get; set; }
    }
}
