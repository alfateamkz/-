using Alfateam.Telephony.Models.ExternalInteractions.Items.Callback;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Telephony.API.Models.DTO.ExternalInteractions.Items.Callback
{
    public class CallbackExtInteractionBannedIPDTO : DTOModelAbs<CallbackExtInteractionBannedIP>
    {
        public string IP { get; set; }
    }
}
