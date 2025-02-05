using Alfateam.Marketing.Models.Websites.SEO.SettingsItems;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.Websites.SEO.SettingsItems
{
    public class ProxyDTO : DTOModelAbs<Proxy>
    {
        public string Host { get; set; }
        public int Port { get; set; }



        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
