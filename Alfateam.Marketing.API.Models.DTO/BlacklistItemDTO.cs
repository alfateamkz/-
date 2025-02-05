using Alfateam.Marketing.API.Models.DTO.General;
using Alfateam.Marketing.Models;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO
{
    public class BlacklistItemDTO : DTOModelAbs<BlacklistItem>
    {
        public ContactInfoDTO Contact { get; set; }
        public string? Name { get; set; }
        public string? Comment { get; set; }
    }
}
