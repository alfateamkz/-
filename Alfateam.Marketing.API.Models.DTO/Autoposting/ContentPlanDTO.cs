using Alfateam.Core.Attributes.DTO;
using Alfateam.Marketing.API.Models.DTO.Abstractions;
using Alfateam.Marketing.Models.Abstractions;
using Alfateam.Marketing.Models.Autoposting;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.Autoposting
{
    public class ContentPlanDTO : DTOModelAbs<ContentPlan>
    {
        public string Title { get; set; }
        public string? Description { get; set; }


        public bool IsActive { get; set; }


        [ForClientOnly]
        public List<AutopostingAccountDTO> Accounts { get; set; } = new List<AutopostingAccountDTO>();

        [ForClientOnly]
        public List<PostDTO> Posts { get; set; } = new List<PostDTO>();
    }
}
