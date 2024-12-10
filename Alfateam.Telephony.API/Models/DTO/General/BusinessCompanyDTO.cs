using Alfateam.Core.Attributes.DTO;
using Alfateam.Telephony.Models.General;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Telephony.API.Models.DTO.General
{
    public class BusinessCompanyDTO : DTOModelAbs<BusinessCompany>
    {
        public string Title { get; set; }
        public string LegalAddress { get; set; }
        public string? ActualAddress { get; set; }


        [ForClientOnly]
        public string? LogoPath { get; set; }
    }
}
