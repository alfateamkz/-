using Alfateam.EDM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.General
{
    public class Business : AbsModel
    {
        public List<Company> Companies { get; set; } = new List<Company>();
        public SubscriptionInfo Info { get; set; }
    }
}
