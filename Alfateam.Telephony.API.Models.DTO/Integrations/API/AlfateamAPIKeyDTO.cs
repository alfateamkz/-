using Alfateam.Core.Attributes.DTO;
using Alfateam.Telephony.Models.Integrations.API;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Telephony.API.Models.DTO.Integrations.API
{
    public class AlfateamAPIKeyDTO : DTOModelAbs<AlfateamAPIKey>
    {
        public string Title { get; set; }

        [ForClientOnly]
        public string Key { get; set; }
        public bool IsEnabled { get; set; }



        [ForClientOnly]
        public DateTime? PaidBefore { get; set; }
    }
}
