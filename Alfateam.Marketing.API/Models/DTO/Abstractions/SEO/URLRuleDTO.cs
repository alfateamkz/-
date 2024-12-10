using Alfateam.Marketing.API.Models.DTO.Websites.SEO.SettingsItems.Rules;
using Alfateam.Marketing.Models.Abstractions.SEO;
using Alfateam.Marketing.Models.Websites.SEO.SettingsItems.Rules;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;

namespace Alfateam.Marketing.API.Models.DTO.Abstractions.SEO
{
    [JsonConverter(typeof(JsonKnownTypesConverter<URLRuleDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(LengthURLRuleDTO), "LengthURLRule")]
    [JsonKnownType(typeof(StringURLRuleDTO), "StringURLRule")]
    public class URLRuleDTO : DTOModelAbs<URLRule>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        public bool IncludeURLs { get; set; }
    }
}
