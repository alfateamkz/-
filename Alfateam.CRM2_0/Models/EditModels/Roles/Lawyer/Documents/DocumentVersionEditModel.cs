using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Lawyer;
using Alfateam.CRM2_0.Models.Roles.Lawyer.Documents;

namespace Alfateam.CRM2_0.Models.EditModels.Roles.Lawyer.Documents
{
	public class DocumentVersionEditModel : EditModel<DocumentVersion>
	{
		public DocumentVersionStatus Status { get; set; } = DocumentVersionStatus.Review;
		public int VersionNumber { get; set; }


		public string? SecondSideComment { get; set; }
		public string? LawyerComment { get; set; }
	}
}
