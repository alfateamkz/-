using Alfateam.Core.Attributes.DTO;
using Alfateam.Sales.API.Models.DTO.Abstractions.Tasks;
using Alfateam.Sales.Models.Abstractions.Tasks;
using Alfateam.Sales.Models.Tasks.CompletionCheck;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Sales.API.Models.DTO.Tasks.CompletionCheck
{
    public class TaskCompletionCheckResultDTO : DTOModelAbs<TaskCompletionCheckResult>
    {
        [ForClientOnly]
        public MarkedAsCompletedDTO MarkedAsCompleted { get; set; }
     
        [HiddenFromClient]
        [DTOFieldFor(DTOFieldForType.CreationOnly)]
        public int MarkedAsCompletedId { get; set; }



        [DTOFieldFor(DTOFieldForType.CreationOnly)]
        public bool IsCompleted { get; set; }
        [DTOFieldFor(DTOFieldForType.CreationOnly)]
        public string? Comment { get; set; }
    }
}
