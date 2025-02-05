using Alfateam.Core.Attributes.DTO;
using Alfateam.Sales.Models.Funnel;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Sales.API.Models.DTO.Funnel
{
    public class SalesFunnelDTO : DTOModelAbs<SalesFunnel>
    {
        public string Title { get; set; }
        public string? Description { get; set; }


        [ForClientOnly]
        public List<SalesFunnelStageDTO> Stages { get; set; } = new List<SalesFunnelStageDTO>();
    }
}
