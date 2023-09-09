using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.ClientModels.General;
using Alfateam.CRM2_0.Models.General;
using Alfateam.CRM2_0.Models.Roles.Lawyer.Trial;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Lawyer.Trial
{
	public class CourtClientModel : ClientModel<Court>
	{
		public string Title { get; set; }
		public AddressClientModel Address { get; set; }


		public CourtStructureClientModel Structure { get; set; }
	}
}
