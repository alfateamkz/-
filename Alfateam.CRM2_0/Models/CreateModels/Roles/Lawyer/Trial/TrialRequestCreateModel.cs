using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Lawyer.Trial;
using Alfateam.CRM2_0.Models.Roles.Lawyer.Trial;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.Lawyer.Trial
{
	public class TrialRequestCreateModel : CreateModel<TrialRequest>
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public TrialRequestType Type { get; set; } = TrialRequestType.Lawsuit;
		public TrialRequestStatus Status { get; set; } = TrialRequestStatus.Preparing;



		public int CourtId { get; set; }



		/// <summary>
		/// Сам исковой документ
		/// </summary>
		public int DocumentId { get; set; }
	}
}
