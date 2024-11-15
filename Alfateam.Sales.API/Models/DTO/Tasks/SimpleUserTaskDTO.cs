using Alfateam.Sales.API.Models.DTO.Abstractions.Tasks;

namespace Alfateam.Sales.API.Models.DTO.Tasks
{
    public class SimpleUserTaskDTO : UserTaskDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
