using Alfateam.Core.Attributes.DTO;
using Alfateam.EDM.API.Models.DTO.General.Subjects;
using Alfateam.EDM.Models.General;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.EDM.API.Models.DTO.General
{
    public class BusinessDTO : DTOModelAbs<Business>
    {
        [ForClientOnly]
        public string Domain { get; set; }


        [ForClientOnly]
        public List<CompanyDTO> Companies { get; set; } = new List<CompanyDTO>();
        [ForClientOnly]
        public SubscriptionInfoDTO Info { get; set; }



    }
}
