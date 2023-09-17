using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Compliance.Conflicts;
using Alfateam.CRM2_0.Models.Roles.Compliance.Conflicts;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Compliance.Conflicts
{
	public class ConflictResolutionProposalClientModel : ClientModel<ConflictResolutionProposal>
	{
		/// <summary>
		 /// Сторона конфликта, от которой поступило предложение
		 /// </summary>
		public ConflictSideClientModel From { get; set; }

		/// <summary>
		/// Стороны конфликта, которым адресовано предложение
		/// </summary>
		public List<ConflictSideClientModel> To { get; set; } = new List<ConflictSideClientModel>();


		public string Title { get; set; }
		public string Description { get; set; }


		public ConflictResolutionProposalStatus Status { get; set; } 
	}
}
