using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Compliance;

namespace Alfateam.CRM2_0.Models.EditModels.Roles.Compliance
{
	public class ComplianceRequirementsCategoryEditModel : EditModel<ComplianceRequirementsCategory>
	{
		public string Title { get; set; }
		public string Description { get; set; }
	}
}
