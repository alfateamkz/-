using Alfateam.Marketing.API.Models.DTO.Abstractions.SEO;
using Alfateam.Marketing.Models.Enums.SEO;

namespace Alfateam.Marketing.API.Models.DTO.Websites.SEO.SettingsItems.Rules
{
    public class StringURLRuleDTO : URLRuleDTO
    {
        public string Value { get; set; }
        public URLComparisonType Type { get; set; }
    }
}
