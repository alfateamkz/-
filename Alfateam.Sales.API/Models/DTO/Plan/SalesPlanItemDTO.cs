using Alfateam.Sales.Models.Plan;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Sales.API.Models.DTO.Plan
{
    public class SalesPlanItemDTO : DTOModelAbs<SalesPlanItem>
    {
        public string Title { get; set; }
        public string? Description { get; set; }


        public int SalesCount { get; set; }
        public double SumOfSales { get; set; }
        public double AverageCheque { get; set; }
    }
}
