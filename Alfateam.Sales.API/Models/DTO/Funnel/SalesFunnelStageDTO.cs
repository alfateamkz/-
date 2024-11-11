using Alfateam.Core.Attributes.DTO;
using Alfateam.Sales.Models.Enums;
using Alfateam.Sales.Models.Funnel;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Sales.API.Models.DTO.Funnel
{
    public class SalesFunnelStageDTO : DTOModelAbs<SalesFunnelStage>
    {
        public string Title { get; set; }
        public string? Description { get; set; }



        [ForClientOnly]
        public SalesFunnelStageTypeDTO Type { get; set; }
        public int TypeId { get; set; }

    }
}
