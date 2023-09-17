using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Compliance;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.Compliance
{
	public class ComplianceRequirementsCreateModel : CreateModel<ComplianceRequirements>
	{
		public string Title { get; set; }
		public string Description { get; set; }


		public int CategoryId { get; set; }
	}
}
