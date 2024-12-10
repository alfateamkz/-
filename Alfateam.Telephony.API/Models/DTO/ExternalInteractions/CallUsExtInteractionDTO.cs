using Alfateam.Telephony.API.Models.DTO.Abstractions;
using Alfateam.Telephony.API.Models.DTO.ExternalInteractions.Items.CallUs;
using Alfateam.Telephony.Models.ExternalInteractions.Items.CallUs;

namespace Alfateam.Telephony.API.Models.DTO.ExternalInteractions
{
    public class CallUsExtInteractionDTO : ExtInteractionDTO
    {
        public string ButtonText { get; set; }
        public string TextFromUnsupportedBrowsers { get; set; }
        public CallUsDMTFDTO DMTF { get; set; }

        public CallUsStyleDTO Style { get; set; }
    }
}
