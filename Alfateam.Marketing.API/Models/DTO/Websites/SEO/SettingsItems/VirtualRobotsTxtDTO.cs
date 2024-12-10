using Alfateam.Marketing.Models.Websites.SEO.SettingsItems;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.Websites.SEO.SettingsItems
{
    public class VirtualRobotsTxtDTO : DTOModelAbs<VirtualRobotsTxt>
    {
        public bool UseVirtual { get; set; }
        public string Content { get; set; }
    }
}
