using Alfateam.EDM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.General
{
    public class SubscriptionInfo : AbsModel
    {
        public int OutgoingDocumentsLeftCount { get; set; }
        public DateTime SubscriptionBefore { get; set; }

    }
}
