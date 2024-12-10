using Alfateam.Telephony.API.Models.DTO.ExternalInteractions.Items.Callback.VisitedPages;
using Alfateam.Telephony.Models.ExternalInteractions.Items.Callback;
using Alfateam.Telephony.Models.ExternalInteractions.Items.Callback.VisitedPages;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Telephony.API.Models.DTO.ExternalInteractions.Items.Callback
{
    public class CallbackClientsScoringCriteriasDTO : DTOModelAbs<CallbackClientsScoringCriterias>
    {
        public int WentToOtherPageScore { get; set; }
        public int ScrolledDownScore { get; set; }
        public int ActiveMoreThan60SecondsScore { get; set; }

        public CallbackClientsScoringVisitedPagesDTO ScoringVisitedPages { get; set; }
        public int VisitedMoreThan3PagesScore { get; set; }
        public int IntensivelyMovedCursorScore { get; set; }
        public int ForEvery30ActiveSecondsAfter60SecondsScore { get; set; }
    }
}
