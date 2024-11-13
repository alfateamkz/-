using Alfateam.Sales.Models.Enums;
using Alfateam.Sales.Models.General;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Sales.API.Models.DTO.General
{
    public class ContactInfoDTO : DTOModelAbs<ContactInfo>
    {
        public ContactType Type { get; set; }
        public string Contact { get; set; }

        public string? Comment { get; set; }
    }
}
