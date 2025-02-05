using Alfateam.Telephony.Models.ExternalInteractions.Items.Callback.UICustomization;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Telephony.API.Models.DTO.ExternalInteractions.Items.Callback.UICustomization
{
    public class CallbackUICustomizationPrivacyDTO : DTOModelAbs<CallbackUICustomizationPrivacy>
    {
        public string Header { get; set; }
        public string LinkText { get; set; }
        public string FullTextOfPrivacy { get; set; }
    }
}
