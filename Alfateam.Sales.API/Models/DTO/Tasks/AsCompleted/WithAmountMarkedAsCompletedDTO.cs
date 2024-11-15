using Alfateam.Sales.API.Models.DTO.Abstractions.Tasks;

namespace Alfateam.Sales.API.Models.DTO.Tasks.AsCompleted
{
    public class WithAmountMarkedAsCompletedDTO : MarkedAsCompletedDTO
    {
        public double Amount { get; set; }
    }
}
