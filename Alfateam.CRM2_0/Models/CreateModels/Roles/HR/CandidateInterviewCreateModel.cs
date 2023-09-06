using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.EditModels.Roles.HR;
using Alfateam.CRM2_0.Models.Roles.HR;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.HR
{
    public class CandidateInterviewCreateModel : CreateModel<CandidateInterview>
    {
        public string Title { get; set; }
        public string? Description { get; set; }

        public CandidateCallCreateModel Call { get; set; }

        public override CandidateInterview Create()
        {
            var item = base.Create();
            item.Call = Call.Create();

            return item;
        }
    }
}
