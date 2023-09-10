using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Lawyer.Documents;
using Alfateam.CRM2_0.Models.Enums.Roles.Lawyer.Trial;
using Alfateam.CRM2_0.Models.Roles.Lawyer.Trial;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Lawyer.Trial
{
	public class TrialRequestClientModel : ClientModel<TrialRequest>
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public TrialRequestType Type { get; set; }
		public TrialRequestStatus Status { get; set; }



		public CourtClientModel Court { get; set; }



		/// <summary>
		/// Сам исковой документ
		/// </summary>
		public DocumentClientModel Document { get; set; }



		public TrialRequestResultClientModel? Result { get; set; }
	}
}
