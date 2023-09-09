using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.General;
using Alfateam.CRM2_0.Models.Roles.Lawyer.Trial;

namespace Alfateam.CRM2_0.Models.EditModels.Roles.Lawyer.Trial
{
	public class CourtEditModel : EditModel<Court>
	{
		public string Title { get; set; }
		public Address Address { get; set; }


		public int StructureId { get; set; }
	}
}
