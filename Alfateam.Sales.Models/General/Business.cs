using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.General
{
    public class Business : AbsModel
    {
        public string Domain { get; set; }

        public List<BusinessCompany> Companies { get; set; } = new List<BusinessCompany>();
        public SubscriptionInfo SubscriptionInfo { get; set; }


        //Alfateam ID владельца бизнеса(домена). Нужен, чтобы не было на одном Alfateam ID несколько доменов
        public string OwnerAlfateamID { get; set; }
    }
}
