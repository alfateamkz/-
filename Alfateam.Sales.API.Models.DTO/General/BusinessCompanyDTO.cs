using Alfateam.Core.Attributes.DTO;
using Alfateam.Sales.Models.General;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Sales.API.Models.DTO.General
{
    public class BusinessCompanyDTO : DTOModelAbs<BusinessCompany>
    {
        public string Title { get; set; }
        public string LegalAddress { get; set; }
        public string? ActualAddress { get; set; }



        [ForClientOnly]
        public string? LogoPath { get; set; }




        [ForClientOnly]
        public CurrencyDTO MainCurrency { get; set; }
        [HiddenFromClient]
        public int MainCurrencyId { get; set; }

    }
}
