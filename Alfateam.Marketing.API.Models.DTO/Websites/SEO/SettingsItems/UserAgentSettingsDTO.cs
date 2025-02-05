using Alfateam.Core.Attributes.DTO;
using Alfateam.Marketing.API.Models.DTO.General.SEO.UserAgents;
using Alfateam.Marketing.Models.General.SEO.UserAgents;
using Alfateam.Marketing.Models.Websites.SEO.SettingsItems;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.Websites.SEO.SettingsItems
{
    public class UserAgentSettingsDTO : DTOModelAbs<UserAgentSettings>
    {

        [ForClientOnly]
        public UserAgentCategoryDTO Category { get; set; }

        [HiddenFromClient]
        public int CategoryId { get; set; }



        [ForClientOnly]
        public UserAgentTemplateDTO Template { get; set; }

        [HiddenFromClient]
        public int TemplateId { get; set; }



        public string HTTPUserAgent { get; set; }
        public string RobotsUserAgent { get; set; }


        public bool IsDefault { get; set; }
    }
}
