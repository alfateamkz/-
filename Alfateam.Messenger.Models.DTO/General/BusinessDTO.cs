using Alfateam.Core.Attributes.DTO;
using Alfateam.Messenger.Models.General;
using Alfateam.Website.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.General
{
    public class BusinessDTO : DTOModelAbs<Business>
    {
        [ForClientOnly]
        public string Domain { get; set; }


        [ForClientOnly]
        public SubscriptionInfo SubscriptionInfo { get; set; }
        [ForClientOnly]
        public List<CompanyWorkSpace> Workspaces { get; set; } = new List<CompanyWorkSpace>();
    }
}
