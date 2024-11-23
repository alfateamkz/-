using Alfateam.Core.Attributes.DTO;
using Alfateam.Sales.Models.Enums;
using Alfateam.Sales.Models.Enums.Statuses;
using Alfateam.Sales.Models.Funnel;
using Alfateam.Website.API.Abstractions;
using System.ComponentModel;

namespace Alfateam.Sales.API.Models.DTO.Funnel
{
    public class SalesFunnelStageDTO : DTOModelAbs<SalesFunnelStage>
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public string BGHexColor { get; set; }
        public string TextHexColor { get; set; }



        [ForClientOnly]
        public SalesFunnelStageStatus Status { get; set; }

        [ForClientOnly]
        public bool IsSystemStage { get; set; }

        [ForClientOnly]
        public int Order { get; set; }






        [Description("Информация о туннеле продаж, если задана")]
        public SalesFunnelTunnelDTO? Tunnel { get; set; }

    }
}
