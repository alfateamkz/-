using Alfateam.Sales.Models.General;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Sales.API.Models.DTO.General
{
    public class CompanyInfoDTO : DTOModelAbs<CompanyInfo>
    {
        public string CountryCode { get; set; }


        public string LegalName { get; set; }
        public string LegalInfo { get; set; }



        public string LegalAddress { get; set; }
        public string? ActualAddress { get; set; }
    }
}
