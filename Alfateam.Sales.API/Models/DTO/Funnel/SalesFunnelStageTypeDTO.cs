using Alfateam.Sales.Models.Funnel;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Sales.API.Models.DTO.Funnel
{
    public class SalesFunnelStageTypeDTO : DTOModelAbs<SalesFunnelStageType>
    {
        public string Title { get; set; }


        public string HexBGColor { get; set; }
        public string HexTitleColor { get; set; }
    }
}
