using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alfateam.Core;

namespace Alfateam.EDM.Models.Documents.DocumentSigning
{
    /// <summary>
    /// Модель подписанного документа
    /// </summary>
    public class SignedDocument : AbsModel
    {
        public SignatureType SignatureType { get; set; }

        public DocumentVersion Version { get; set; }
        public int VersionId { get; set; }


        /// <summary>
        /// Сканы подписанного документа разными сторонами
        /// Используется, если SignatureType == TraditionalSignature
        /// </summary>
        public List<DocumentSigningSideScan> Scans { get; set; } = new List<DocumentSigningSideScan>();




        /// <summary>
        /// Провайдер ЭДО
        /// Используется, если SignatureType == SignedByOtherEDM
        /// </summary>
        public EDMProvider? EDMProvider { get; set; }
        public int? EDMProviderId { get; set; }


        /// <summary>
        /// Данные роуминга с другим провайдером ЭДО
        /// Используется, если SignatureType == AlfateamEDM и если имеется роуминг с другим провайдером ЭДО
        /// </summary>
        public SignedDocumentRoamingInfo RoamingInfo { get; set; }
    }
}
