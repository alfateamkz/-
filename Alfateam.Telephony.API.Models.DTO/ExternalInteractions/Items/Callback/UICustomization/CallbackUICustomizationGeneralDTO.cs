using Alfateam.Telephony.API.Models.DTO.ExternalInteractions.Items.Callback.UICustomization.Texts;
using Alfateam.Telephony.Models.Enums;
using Alfateam.Telephony.Models.ExternalInteractions.Items.Callback.UICustomization;
using Alfateam.Telephony.Models.ExternalInteractions.Items.Callback.UICustomization.Texts;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Telephony.API.Models.DTO.ExternalInteractions.Items.Callback.UICustomization
{
    public class CallbackUICustomizationGeneralDTO : DTOModelAbs<CallbackUICustomizationGeneral>
    {
        public int CountdownSeconds { get; set; }
        public string ImgPath { get; set; }



        public CallbackUICustomizationGeneralButtonPosition ButtonPosition { get; set; }
        public int X_Px_Margin { get; set; }
        public int Y_Px_Margin { get; set; }



        public string ButtonText { get; set; }


        public CallbackUICustomizationTextsWorkingTimeDTO TextsWorkingTime { get; set; }
        public CallbackUICustomizationTextsLeavingSiteDTO TextsLeavingSite { get; set; }
        public CallbackUICustomizationTextsNotWorkingTimeDTO TextsNotWorkingTime { get; set; }
        public CallbackUICustomizationTextsDelayedCallDTO TextsDelayedCall { get; set; }
    }
}
