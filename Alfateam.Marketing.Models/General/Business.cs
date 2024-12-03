using Alfateam.Core;
using Alfateam.Marketing.Models.Integrations.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.General
{
    public class Business : AbsModel
    {
        public string Domain { get; set; }

        public List<BusinessCompany> Companies { get; set; } = new List<BusinessCompany>();
        public SubscriptionInfo SubscriptionInfo { get; set; }
        public List<AlfateamAPIKey> APIKeys { get; set; } = new List<AlfateamAPIKey>();








        //Alfateam ID владельца бизнеса(домена). Нужен, чтобы не было на одном Alfateam ID несколько доменов
        public string OwnerAlfateamID { get; set; }
    }
}
