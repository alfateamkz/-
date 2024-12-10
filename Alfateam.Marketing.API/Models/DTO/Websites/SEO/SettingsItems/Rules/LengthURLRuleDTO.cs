using Alfateam.Marketing.API.Models.DTO.Abstractions.SEO;
using Alfateam.Marketing.Models.Enums.SEO;

namespace Alfateam.Marketing.API.Models.DTO.Websites.SEO.SettingsItems.Rules
{
    public class LengthURLRuleDTO : URLRuleDTO
    {
        public int Length { get; set; }
        public LengthURLRuleCondition Type { get; set; }
    }
}
