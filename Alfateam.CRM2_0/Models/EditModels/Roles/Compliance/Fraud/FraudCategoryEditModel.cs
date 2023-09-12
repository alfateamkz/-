using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Compliance.Fraud;

namespace Alfateam.CRM2_0.Models.EditModels.Roles.Compliance.Fraud
{
	public class FraudCategoryEditModel : EditModel<FraudCategory>
	{
		public string Title { get; set; }
		public string? Description { get; set; }
	}
}
