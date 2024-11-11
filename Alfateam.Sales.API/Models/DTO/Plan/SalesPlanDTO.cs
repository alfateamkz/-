using Alfateam.Core.Attributes.DTO;
using Alfateam.Sales.Models.Plan;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Sales.API.Models.DTO.Plan
{
    public class SalesPlanDTO : DTOModelAbs<SalesPlan>
    {
        public string Title { get; set; }
        public string? Description { get; set; }


        [ForClientOnly]
        public List<SalesPlanItemDTO> Items { get; set; } = new List<SalesPlanItemDTO>();
    }
}
