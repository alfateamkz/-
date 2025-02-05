using Alfateam.Sales.API.Models.DTO.Abstractions;
using Alfateam.Sales.API.Models.DTO.Plan.Types.Items;
using Alfateam.Sales.Models.Plan.Types.Items;

namespace Alfateam.Sales.API.Models.DTO.Plan.Types
{
    public class ByManagersSalesPlanDTO : SalesPlanDTO
    {
        public List<ByManagersSalesPlanManagerDTO> Managers { get; set; } = new List<ByManagersSalesPlanManagerDTO>();
    }
}
