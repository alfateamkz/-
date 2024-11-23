using Alfateam.Core.Attributes.DTO;
using Alfateam.Sales.API.Models.DTO.Abstractions;
using Alfateam.Sales.Models.Plan;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Sales.API.Models.DTO.Plan
{
    public class SalesPlanningDTO : DTOModelAbs<SalesPlanning>
    {
        public string Title { get; set; }
        public string? Description { get; set; }


        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }



        [ForClientOnly]
        public List<SalesPlanDTO> Plans { get; set; } = new List<SalesPlanDTO>();
    }
}
