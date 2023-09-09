using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Lawyer.Trial;

namespace Alfateam.CRM2_0.Models.EditModels.Roles.Lawyer.Trial
{
	public class TrialHearingEditModel : EditModel<TrialHearing>
	{
		public int JudgeId { get; set; }
		public int CourtId { get; set; }


		public DateTime Date { get; set; }
	}
}
