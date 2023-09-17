using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Compliance;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.Compliance
{
	public class ComplianceCriteriaGroupCreateModel : CreateModel<ComplianceCriteriaGroup>
	{
		public string Title { get; set; }
		public string? Description { get; set; }
	}
}
