using Alfateam.Marketing.API.Models.DTO.Integrations.Metrics.Apps;
using Alfateam.Marketing.API.Models.DTO.Integrations.Metrics.Websites;
using Alfateam.Marketing.API.Models.DTO.Integrations.SEO;
using Alfateam.Marketing.Models.Abstractions.Integrations;
using Alfateam.Marketing.Models.Integrations.Metrics.Apps;
using Alfateam.Marketing.Models.Integrations.Metrics.Websites;
using Alfateam.Marketing.Models.Integrations.SEO;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;

namespace Alfateam.Marketing.API.Models.DTO.Abstractions.Integrations
{

    [JsonConverter(typeof(JsonKnownTypesConverter<IntegrationDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(MobileAppIntegrationDTO), "MobileAppIntegration")]
    [JsonKnownType(typeof(WebsiteIntegrationDTO), "WebsiteIntegration")]

    [JsonKnownType(typeof(AppmetrikaIntegrationDTO), "AppmetrikaIntegration")]
    [JsonKnownType(typeof(AppsFlyerIntegrationDTO), "AppsFlyerIntegration")]

    [JsonKnownType(typeof(GoogleAnalyticsIntegrationDTO), "GoogleAnalyticsIntegration")]
    [JsonKnownType(typeof(YandexMetrikaIntegrationDTO), "YandexMetrikaIntegration")]

    [JsonKnownType(typeof(GooglePageSpeedInsightsIntegrationDTO), "GooglePageSpeedInsightsIntegration")]
    [JsonKnownType(typeof(GoogleSearchConsoleIntegrationDTO), "GoogleSearchConsoleIntegration")]
    [JsonKnownType(typeof(GoogleTrendsIntegrationDTO), "GoogleTrendsIntegration")]
    [JsonKnownType(typeof(UniversalAnalyticsIntegrationDTO), "UniversalAnalyticsIntegration")]
    [JsonKnownType(typeof(YandexWebmasterIntegrationDTO), "YandexWebmasterIntegration")]
    public class IntegrationDTO : DTOModelAbs<Integration>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }
    }
}
