using Alfateam.Telephony.Models.ExternalInteractions.Items.CallUs;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Telephony.API.Models.DTO.ExternalInteractions.Items.CallUs
{
    public class CallUsStyleColorsDTO : DTOModelAbs<CallUsStyleColors>
    {
        public string TextHexColor { get; set; }
        public string TextBGColor { get; set; }
        public string TextBorderColor { get; set; }
    }
}
