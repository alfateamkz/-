using Alfateam.Marketing.API.Models.DTO.Abstractions.SEO;
using Alfateam.Marketing.Models.Abstractions.SEO;
using Alfateam.Marketing.Models.Enums.SEO;
using Alfateam.Marketing.Models.Websites.SEO.SettingsItems;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.Websites.SEO.SettingsItems
{
    public class URLRulesDTO : DTOModelAbs<URLRules>
    {
        public bool UseRules { get; set; }
        public bool GoToFilteredURLs { get; set; }

        public URLRulesType Type { get; set; }


        public List<URLRuleDTO> Rules { get; set; } = new List<URLRuleDTO>();
    }
}
