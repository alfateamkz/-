using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Lawyer;
using Alfateam.CRM2_0.Models.Roles.Lawyer.Documents;

namespace Alfateam.CRM2_0.Models.EditModels.Roles.Lawyer.Documents
{
	public class DocumentEditModel : EditModel<Document>
	{
		public DocumentType Type { get; set; }
		public string Title { get; set; }
		public string? DocumentNumber { get; set; }
	}
}
