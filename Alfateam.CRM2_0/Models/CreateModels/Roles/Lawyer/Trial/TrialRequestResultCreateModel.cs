using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Lawyer.Trial;
using Alfateam.CRM2_0.Models.Roles.Lawyer.Trial;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.Lawyer.Trial
{
	public class TrialRequestResultCreateModel : CreateModel<TrialRequestResult>
	{
		public TrialRequestResultType Type { get; set; } = TrialRequestResultType.Approved;
		public string Description { get; set; }


		/// <summary>
		/// Назначенное слушание в случае, если Type == TrialRequestResultType.Approved
		/// </summary>
		public TrialHearingCreateModel? ScheduledHearing { get; set; }

		public override bool IsValid()
		{
			return base.IsValid();
		}

		public override TrialRequestResult Create()
		{
			var result = base.Create();

			if(ScheduledHearing != null)
			{
				result.ScheduledHearing = ScheduledHearing.Create();
			}

			return result;
		}
	}
}
