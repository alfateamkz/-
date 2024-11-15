using Alfateam.Sales.API.Abstractions;
using Alfateam.Sales.Models.Enums;

namespace Alfateam.Sales.API.Models.SearchFilters.Tasks
{
    public class TasksAssignedByMeSearchFilter : SearchFilter
    {
        public bool? DeadlinePassed { get; set; }
        public UserTaskStatus? Status { get; set; }
        public int? TaskForId { get; set; }
    }
}
