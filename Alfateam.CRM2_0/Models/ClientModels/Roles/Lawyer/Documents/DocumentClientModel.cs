using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.ClientModels.General;
using Alfateam.CRM2_0.Models.Enums.Roles.Lawyer;
using Alfateam.CRM2_0.Models.Roles.Lawyer.Documents;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Lawyer.Documents
{
	public class DocumentClientModel : ClientModel<Document>
	{
		public UserClientModel CreatedBy { get; set; }


		public DocumentType Type { get; set; }
		public string? DocumentNumber { get; set; }
		public List<DocumentVersionClientModel> Versions { get; set; } = new List<DocumentVersionClientModel>();


		public SignedDocumentClientModel? SignedDocument { get; set; }
	}
}
