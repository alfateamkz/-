using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Compliance;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Compliance
{
	public class ComplianceRequirementsClientModel : ClientModel<ComplianceRequirements>
	{
		public string Title { get; set; }
		public string Description { get; set; }


		public ComplianceRequirementsCategoryClientModel Category { get; set; }
		public int CategoryId { get; set; }


		public List<ComplianceCriteriaGroupClientModel> Groups { get; set; } = new List<ComplianceCriteriaGroupClientModel>();
	}
}
