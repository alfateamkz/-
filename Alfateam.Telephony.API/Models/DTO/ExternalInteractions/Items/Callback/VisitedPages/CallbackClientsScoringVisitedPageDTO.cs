using Alfateam.Telephony.Models.ExternalInteractions.Items.Callback.VisitedPages;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Telephony.API.Models.DTO.ExternalInteractions.Items.Callback.VisitedPages
{
    public class CallbackClientsScoringVisitedPageDTO : DTOModelAbs<CallbackClientsScoringVisitedPage>
    {
        public string URL { get; set; }
    }
}
