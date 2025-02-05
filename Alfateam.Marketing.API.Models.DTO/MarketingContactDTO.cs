using Alfateam.Core.Attributes.DTO;
using Alfateam.Marketing.API.Models.DTO.General;
using Alfateam.Marketing.Models;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO
{
    public class MarketingContactDTO : DTOModelAbs<MarketingContact>
    {
        public string? Name { get; set; }
        public ContactInfoDTO Contact { get; set; }



        [ForClientOnly]
        public bool FromAlfateamSalesCRM { get; set; }
    }
}
