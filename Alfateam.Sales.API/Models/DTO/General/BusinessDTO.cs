using Alfateam.Core.Attributes.DTO;
using Alfateam.Sales.Models.General;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Sales.API.Models.DTO.General
{
    public class BusinessDTO : DTOModelAbs<Business>
    {
        [ForClientOnly]
        public string Domain { get; set; }



        [ForClientOnly]
        public List<BusinessCompanyDTO> Companies { get; set; } = new List<BusinessCompanyDTO>();
        [ForClientOnly]
        public SubscriptionInfoDTO SubscriptionInfo { get; set; }
    }
}
