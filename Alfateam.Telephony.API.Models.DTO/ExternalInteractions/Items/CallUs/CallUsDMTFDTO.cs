using Alfateam.Telephony.Models.Enums;
using Alfateam.Telephony.Models.ExternalInteractions.Items.CallUs;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Telephony.API.Models.DTO.ExternalInteractions.Items.CallUs
{
    public class CallUsDMTFDTO : DTOModelAbs<CallUsDMTF>
    {
        public bool IsEnabled { get; set; }
        public CallUsDMTFType Type { get; set; }
        public int ShowTimeInSeconds { get; set; }
    }
}
