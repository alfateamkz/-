using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Compliance;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Compliance
{
	public class ComplianceCriteriaClientModel : ClientModel<ComplianceCriteria>
	{
		public string Title { get; set; }
		public string Description { get; set; }
	}
}
