using Alfateam.Core.Attributes.DTO;
using Alfateam.Sales.Models.Enums;
using Alfateam.Sales.Models.Funnel;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Sales.API.Models.DTO.Funnel
{
    public class SalesFunnelTunnelDTO : DTOModelAbs<SalesFunnelTunnel>
    {
        public SalesFunnelTunnelActionType Type { get; set; }



        [ForClientOnly]
        public SalesFunnelStageDTO FromFunnelStage { get; set; }

        [HiddenFromClient]
        public int FromFunnelStageId { get; set; }







        [ForClientOnly]
        public SalesFunnelStageDTO ToFunnelStage { get; set; }

        [HiddenFromClient]
        public int ToFunnelStageId { get; set; }
    }
}
