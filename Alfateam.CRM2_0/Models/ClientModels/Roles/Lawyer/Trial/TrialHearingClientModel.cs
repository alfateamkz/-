using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.ClientModels.General;
using Alfateam.CRM2_0.Models.General;
using Alfateam.CRM2_0.Models.Roles.Lawyer.Trial;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Lawyer.Trial
{
    public class TrialHearingClientModel : ClientModel<TrialHearing>
    {
        public JudgeClientModel Judge { get; set; }
        public CourtClientModel Court { get; set; }


        public DateTime Date { get; set; }



        public TrialHearingResultClientModel? Result { get; set; }
    }
}
