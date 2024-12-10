using Alfateam.Telephony.API.Models.DTO.ExternalInteractions.Items.Callback.UICustomization;
using Alfateam.Telephony.Models.Enums;
using Alfateam.Telephony.Models.ExternalInteractions.Items.Callback;
using Alfateam.Telephony.Models.ExternalInteractions.Items.Callback.UICustomization;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Telephony.API.Models.DTO.ExternalInteractions.Items.Callback
{
    public class CallbackUICustomizationDTO : DTOModelAbs<CallbackUICustomization>
    {
        public CallbackUICustomizationFormType FormType { get; set; }


        public CallbackUICustomizationGeneralDTO General { get; set; }
        public CallbackUICustomizationPrivacyDTO Privacy { get; set; }
        public CallbackUICustomizationTextsDTO Texts { get; set; }
    }
}
