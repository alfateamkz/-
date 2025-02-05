using Alfateam.Telephony.Models.ExternalInteractions.Items.Callback.VisitedPages;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Telephony.API.Models.DTO.ExternalInteractions.Items.Callback.VisitedPages
{
    public class CallbackClientsScoringVisitedPagesDTO : DTOModelAbs<CallbackClientsScoringVisitedPages>
    {
        public int Score { get; set; }
        public List<CallbackClientsScoringVisitedPageDTO> URLs { get; set; } = new List<CallbackClientsScoringVisitedPageDTO>();
    }
}
