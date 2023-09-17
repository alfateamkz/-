using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Compliance;
using Alfateam.CRM2_0.Models.Roles.Compliance.Law;

namespace Alfateam.CRM2_0.Models.EditModels.Roles.Compliance.Law
{
	public class ProhibitedServiceEditModel : EditModel<ProhibitedService>
	{
		public string Title { get; set; }
		public string? Description { get; set; }

		public ProhibitedServiceType Type { get; set; }
	}
}
