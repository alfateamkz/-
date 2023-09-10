using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Lawyer.Trial;
using Alfateam.CRM2_0.Models.Roles.Lawyer.Trial;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Lawyer.Trial
{
	public class TrialRequestResultClientModel : ClientModel<TrialRequestResult>
	{
		public TrialRequestResultType Type { get; set; }
		public string Description { get; set; }


		/// <summary>
		/// Назначенное слушание в случае, если Type == TrialRequestResultType.Approved
		/// </summary>
		public TrialHearingClientModel? ScheduledHearing { get; set; }
	}
}
