using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.ClientModels.Roles.HR.JobVacancies;
using Alfateam.CRM2_0.Models.Roles.HR;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.HR
{
    public class CandidateInterviewClientModel : ClientModel<CandidateInterview>
    {
        public string Title { get; set; }
        public string? Description { get; set; }

        public JobVacancyClientModel JobVacancy { get; set; }
    }
}
