using Alfateam.Core;
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



        //Alfateam ID владельца бизнеса(домена). Нужен, чтобы не было на одном Alfateam ID несколько доменов
        public string OwnerAlfateamID { get; set; }
    }
}
