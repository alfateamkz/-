using Alfateam.Core.Attributes.DTO;
using Alfateam.Marketing.Models.Integrations.API;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.Integrations.API
{
    public class AlfateamAPIKeyDTO : DTOModelAbs<AlfateamAPIKey>
    {
        public string Title { get; set; }

        [ForClientOnly]
        public string Key { get; set; } = System.Guid.NewGuid().ToString();
        public bool IsEnabled { get; set; } = true;

        
        [ForClientOnly]
        public DateTime? PaidBefore { get; set; }
    }
}
