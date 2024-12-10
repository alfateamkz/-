using Alfateam.Telephony.Models.ExternalInteractions.Items.Callback.UICustomization.Texts;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Telephony.API.Models.DTO.ExternalInteractions.Items.Callback.UICustomization.Texts
{
    public class CallbackUICustomizationTextsWorkingTimeDTO :DTOModelAbs<CallbackUICustomizationTextsWorkingTime>
    {
        public string Header { get; set; }
        public string Text { get; set; }
        public string Button { get; set; }
        public string NumberSample { get; set; }
        public string DelayCall { get; set; }
        public string CountryForbidden { get; set; }
        public string CallsLimitReached { get; set; }




        public string SuccessfulCall { get; set; }
        public string UnsuccessfulCall { get; set; }
        public string RateCall { get; set; }
        public string Busy { get; set; }
        public string RepeatCall { get; set; }
        public string IncorrectNumber { get; set; }
        public string NotWorkingTime { get; set; }
        public string RepeatCallIn1Hour { get; set; }
        public string NextCallIn1Day { get; set; }
    }
}
