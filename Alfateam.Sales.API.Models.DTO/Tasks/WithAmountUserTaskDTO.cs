using Alfateam.Core.Attributes.DTO;
using Alfateam.Sales.API.Models.DTO.Abstractions.Tasks;

namespace Alfateam.Sales.API.Models.DTO.Tasks
{
    public class WithAmountUserTaskDTO : UserTaskDTO
    {
        public double Amount { get; set; }
        public string MeasureUnit { get; set; } 

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }




        [ForClientOnly]
        public double CompletedAmount { get; set; }
    }
}
