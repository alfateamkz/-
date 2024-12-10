using Alfateam.Core.Attributes.DTO;
using Alfateam.Marketing.Models.General.SEO.UserAgents;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.General.SEO.UserAgents
{
    public class UserAgentTemplateDTO : DTOModelAbs<UserAgentTemplate>
    {
        public string Title { get; set; }

        [ForClientOnly]
        public List<UserAgentTemplateDTO> SubTemplates { get; set; } = new List<UserAgentTemplateDTO>();
    }
}
