using Alfateam.Telephony.Models.ExternalInteractions.Items.Callback.UICustomization.Texts;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Telephony.API.Models.DTO.ExternalInteractions.Items.Callback.UICustomization.Texts
{
    public class CallbackUICustomizationTextsDelayedCallDTO : DTOModelAbs<CallbackUICustomizationTextsDelayedCall>
    {
        public string Header { get; set; }
        public string Text { get; set; }
        public string CallNow { get; set; }
        public string ThankForOrder { get; set; }
    }
}
