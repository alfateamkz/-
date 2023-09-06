using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.HR;
using Alfateam.CRM2_0.Models.Roles.HR.TestTasks;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.HR.TestTasks
{
    public class CandidateTestTaskCreateModel : CreateModel<CandidateTestTask>
    {
        public DateTime Deadline { get; set; }
        public string TaskDetails { get; set; }
    }
}
