using Alfateam.Telephony.Models.ExternalInteractions.Items.Callback.UICustomization.Texts;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Telephony.API.Models.DTO.ExternalInteractions.Items.Callback.UICustomization.Texts
{
    public class CallbackUICustomizationTextsLeavingSiteDTO : DTOModelAbs<CallbackUICustomizationTextsLeavingSite>
    {
        public string Header { get; set; }
        public string Text { get; set; }
    }
}
