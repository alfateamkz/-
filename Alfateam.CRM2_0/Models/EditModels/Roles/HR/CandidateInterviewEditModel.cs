using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.HR;
using Alfateam.CRM2_0.Models.Roles.HR.TestTasks;

namespace Alfateam.CRM2_0.Models.EditModels.Roles.HR
{
    public class CandidateInterviewEditModel : EditModel<CandidateInterview>
    {
        public string Title { get; set; }
        public string? Description { get; set; }


        public int JobVacancyId { get; set; }

    }
}
