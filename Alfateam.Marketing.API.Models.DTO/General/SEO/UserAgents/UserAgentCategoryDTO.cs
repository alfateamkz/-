using Alfateam.Marketing.Models.General.SEO.UserAgents;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.General.SEO.UserAgents
{
    public class UserAgentCategoryDTO : DTOModelAbs<UserAgentCategory>
    {
        public string Title { get; set; }
    }
}
