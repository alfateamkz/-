using Alfateam.Marketing.Models.Websites.SEO.SettingsItems;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.Websites.SEO.SettingsItems
{
    public class HTTPHeaderDTO : DTOModelAbs<HTTPHeader>
    {
        public string Header { get; set; }
        public string Value { get; set; }
    }
}
