using Alfateam.Telephony.Models.Enums;
using Alfateam.Telephony.Models.ExternalInteractions.Items.CallUs;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Telephony.API.Models.DTO.ExternalInteractions.Items.CallUs
{
    public class CallUsStyleDTO : DTOModelAbs<CallUsStyle>
    {
        public string Fonts { get; set; }
        public CallUsStyleFormType FormType { get; set; }



        public CallUsStyleColorsDTO InitialStateColors { get; set; }
        public CallUsStyleColorsDTO DialingStateColors { get; set; }
        public CallUsStyleColorsDTO ActiveStateColors { get; set; }
        public CallUsStyleColorsDTO EndedStateColors { get; set; }
    }
}
