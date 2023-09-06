using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.HR;
using Alfateam.CRM2_0.Models.Roles.HR.TestTasks;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.HR.TestTasks
{
    public class CandidateTestTaskClientModel : ClientModel<CandidateTestTask>
    {
        public CandidateTestTaskStatus Status { get; set; } = CandidateTestTaskStatus.Active;
        public DateTime Deadline { get; set; }
        public string TaskDetails { get; set; }
    }
}
