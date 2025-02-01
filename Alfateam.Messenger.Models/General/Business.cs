using Alfateam.Core;
using Alfateam.Messenger.Models.Integrations.API;
using Alfateam.Messenger.Models.Integrations.ExtMessenger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.General
{
    public class Business : AbsModel
    {
        public string Domain { get; set; }

        public SubscriptionInfo SubscriptionInfo { get; set; }
        public List<CompanyWorkSpace> Workspaces { get; set; } = new List<CompanyWorkSpace>();
        public List<AlfateamAPIKey> APIKeys { get; set; } = new List<AlfateamAPIKey>();
        public List<ExtMessengerIntegration> ExtMessengerIntegrations { get; set; } = new List<ExtMessengerIntegration>();





        //Alfateam ID владельца бизнеса(домена). Нужен, чтобы не было на одном Alfateam ID несколько доменов
        public string OwnerAlfateamID { get; set; }
    }
}
