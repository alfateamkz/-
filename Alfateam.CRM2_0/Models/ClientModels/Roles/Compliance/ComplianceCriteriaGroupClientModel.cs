using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Compliance;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Compliance
{
	public class ComplianceCriteriaGroupClientModel : ClientModel<ComplianceCriteriaGroup>
	{
		public string Title { get; set; }
		public string? Description { get; set; }

		public List<ComplianceCriteriaClientModel> Criterias { get; set; } = new List<ComplianceCriteriaClientModel>();
	}
}
