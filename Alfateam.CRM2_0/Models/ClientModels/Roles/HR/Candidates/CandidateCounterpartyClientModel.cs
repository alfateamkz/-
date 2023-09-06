using Alfateam.CRM2_0.Models.ClientModels.Abstractions.Roles.HR;
using Alfateam.CRM2_0.Models.ClientModels.General;
using Alfateam.CRM2_0.Models.General;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.HR.Candidates
{
    public class CandidateCounterpartyClientModel : CandidateClientModel
    {
        public CompanyClientModel Company { get; set; }
    }
}
