using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Lawyer;
using Alfateam.CRM2_0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Lawyer.Documents
{
    /// <summary>
    /// Модель подписанного документа
    /// </summary>
    public class SignedDocument : AbsModel
    {
        public SignatureType SignatureType { get; set; }
        public DocumentVersion Version { get; set; }



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
        public EDMProvider? EDMProvider { get; set; }
    }
}
