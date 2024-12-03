using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Telephony.Models.ExternalInteractions.Items.Callback.VisitedPages
{
    public class CallbackClientsScoringVisitedPages : AbsModel
    {
        public int Score { get; set; }
        public List<CallbackClientsScoringVisitedPage> URLs { get; set; } = new List<CallbackClientsScoringVisitedPage>();
    }
}
