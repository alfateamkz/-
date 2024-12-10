using Alfateam.Marketing.Models.Websites.SEO.SettingsItems;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.Websites.SEO.SettingsItems
{
    public class WebsiteBaseAuthenticationDTO : DTOModelAbs<WebsiteBaseAuthentication>
    {
        public bool UseAuth { get; set; }

        public string? Login { get; set; }
        public string? Password { get; set; }
    }
}
