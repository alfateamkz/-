using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Lawyer;
using Alfateam.CRM2_0.Models.Roles.Lawyer.Documents;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Lawyer.Documents
{
	public class DocumentVersionClientModel : ClientModel<DocumentVersion>
	{
		public DocumentVersionStatus Status { get; set; }

		public int VersionNumber { get; set; }
		public string DocumentFilepath { get; set; }


		public string? SecondSideComment { get; set; }
		public string? LawyerComment { get; set; }
	}
}
