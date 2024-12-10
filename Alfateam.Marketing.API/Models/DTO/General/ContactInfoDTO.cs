using Alfateam.Marketing.Models.Enums;
using Alfateam.Marketing.Models.General;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.General
{
    public class ContactInfoDTO : DTOModelAbs<ContactInfo>
    {
        public ContactType Type { get; set; }
        public string Contact { get; set; }

        public string? Comment { get; set; }
    }
}
