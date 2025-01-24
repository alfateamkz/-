using Alfateam.Core.Attributes.DTO;
using Alfateam.TicketSystem.Models.General;
using Alfateam.Website.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.TicketSystem.Models.DTO.General
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
