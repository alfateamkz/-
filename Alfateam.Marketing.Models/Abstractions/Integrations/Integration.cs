using Alfateam.Core;
using Alfateam.Marketing.Models.Ads.Accounts;
using Alfateam.Marketing.Models.Integrations.Metrics.Apps;
using Alfateam.Marketing.Models.Integrations.Metrics.Websites;
using Alfateam.Marketing.Models.Integrations.SEO;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Abstractions.Integrations
{


    [JsonConverter(typeof(JsonKnownTypesConverter<Integration>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(MobileAppIntegration), "MobileAppIntegration")]
    [JsonKnownType(typeof(WebsiteIntegration), "WebsiteIntegration")]

    [JsonKnownType(typeof(AppmetrikaIntegration), "AppmetrikaIntegration")]
    [JsonKnownType(typeof(AppsFlyerIntegration), "AppsFlyerIntegration")]

    [JsonKnownType(typeof(GoogleAnalyticsIntegration), "GoogleAnalyticsIntegration")]
    [JsonKnownType(typeof(YandexMetrikaIntegration), "YandexMetrikaIntegration")]

    [JsonKnownType(typeof(GooglePageSpeedInsightsIntegration), "GooglePageSpeedInsightsIntegration")]
    [JsonKnownType(typeof(GoogleSearchConsoleIntegration), "GoogleSearchConsoleIntegration")]
    [JsonKnownType(typeof(GoogleTrendsIntegration), "GoogleTrendsIntegration")]
    [JsonKnownType(typeof(UniversalAnalyticsIntegration), "UniversalAnalyticsIntegration")]
    [JsonKnownType(typeof(YandexWebmasterIntegration), "YandexWebmasterIntegration")]
    public class Integration : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }



        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int? BusinessCompanyId { get; set; }
    }
}
