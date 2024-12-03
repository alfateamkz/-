using Alfateam.Core;
using Alfateam.Marketing.Models.Ads.Accounts;
using Alfateam.Marketing.Models.Websites.SEO.SettingsItems.Rules;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Abstractions.SEO
{
    [JsonConverter(typeof(JsonKnownTypesConverter<URLRule>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(LengthURLRule), "LengthURLRule")]
    [JsonKnownType(typeof(StringURLRule), "StringURLRule")]
    public class URLRule : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        public bool IncludeURLs { get; set; }
    }
}
