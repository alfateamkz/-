using Alfateam.Marketing.API.Models.DTO.Ads.Accounts;
using Alfateam.Marketing.Models.Abstractions;
using Alfateam.Marketing.Models.Ads.Accounts;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;

namespace Alfateam.Marketing.API.Models.DTO.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<AdsServiceAccountDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(FacebookAdsServiceAccountDTO), "FacebookAdsServiceAccount")]
    [JsonKnownType(typeof(GoogleAdsAdsServiceAccountDTO), "GoogleAdsAdsServiceAccount")]
    [JsonKnownType(typeof(VKAdsServiceAccountDTO), "VKAdsServiceAccount")]
    [JsonKnownType(typeof(YandexDirectAdsServiceAccountDTO), "YandexDirectAdsServiceAccount")]
    public class AdsServiceAccountDTO : DTOModelAbs<AdsServiceAccount>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        public string Title { get; set; }
    }
}
