using Alfateam.Core.Attributes.DTO;

namespace Alfateam.Marketing.API.Models.DTO.Abstractions.Integrations
{
    public class WebsiteIntegrationDTO : IntegrationDTO
    {
        [DTOFieldFor(DTOFieldForType.CreationOnly)]
        public int WebsiteId { get; set; }
    }
}
