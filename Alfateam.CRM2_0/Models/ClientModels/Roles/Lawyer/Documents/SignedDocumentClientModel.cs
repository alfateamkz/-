using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.ClientModels.General;
using Alfateam.CRM2_0.Models.Enums.Roles.Lawyer;
using Alfateam.CRM2_0.Models.General;
using Alfateam.CRM2_0.Models.Roles.Lawyer.Documents;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Lawyer.Documents
{
	public class SignedDocumentClientModel : ClientModel<SignedDocument>
	{
		public SignatureType SignatureType { get; set; }
		public DocumentVersionClientModel Version { get; set; }



		/// <summary>
		/// Путь к скану документа со стороны корпорации Alfateam
		/// Используется, если SignatureType == TraditionalSignature
		/// </summary>
		public string? AlfateamSideDocumentScan { get; set; }
		/// <summary>
		/// Путь к скану документа со стороны клиента/контрагента
		/// Используется, если SignatureType == TraditionalSignature
		/// </summary>
		public string? SecondSideDocumentScan { get; set; }



		/// <summary>
		/// Провайдер ЭДО
		/// Используется, если SignatureType == DigitalSignature
		/// </summary>
		public EDMProviderClientModel? EDMProvider { get; set; }
	}
}
