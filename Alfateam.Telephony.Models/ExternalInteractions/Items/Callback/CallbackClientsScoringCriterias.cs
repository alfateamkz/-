using Alfateam.Core;
using Alfateam.Telephony.Models.ExternalInteractions.Items.Callback.VisitedPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Telephony.Models.ExternalInteractions.Items.Callback
{
    public class CallbackClientsScoringCriterias : AbsModel
    {
        public int WentToOtherPageScore { get; set; }
        public int ScrolledDownScore { get; set; }
        public int ActiveMoreThan60SecondsScore { get; set; }

        public CallbackClientsScoringVisitedPages ScoringVisitedPages { get; set; }
        public int VisitedMoreThan3PagesScore { get; set; }
        public int IntensivelyMovedCursorScore { get; set; }
        public int ForEvery30ActiveSecondsAfter60SecondsScore { get; set; }

    }
}
