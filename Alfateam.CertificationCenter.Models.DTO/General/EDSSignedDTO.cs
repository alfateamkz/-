using Alfateam.CertificationCenter.Models.Enums;
using Alfateam.CertificationCenter.Models.General;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.CertificationCenter.Models.DTO.General
{
    public class EDSSignedDTO : DTOModelAbs<EDSSigned>
    {
        public string EDSCountryCode { get; set; }
        public EDSSignedType Type { get; set; }

        public string SignedHash { get; set; }
    }
}
