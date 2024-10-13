using Alfateam.Core;
using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.Enums;
using Alfateam.EDM.Models.Enums.DocumentStatuses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Documents.DocumentSigning
{
    public class DocumentCancellationMetadata : AbsModel
    {
        public DocumentCancellationResult Status { get; set; } = DocumentCancellationResult.NotCancelled;



        public SignatureType SignatureType { get; set; }
        public List<DocumentSigningResult> SigningResults { get; set; } = new List<DocumentSigningResult>();



        /// <summary>
        /// Данные роуминга с другим провайдером ЭДО
        /// Используется, если SignatureType == AlfateamEDM и если имеется роуминг с другим провайдером ЭДО
        /// </summary>
        public SignedDocumentRoamingInfo? RoamingInfo { get; set; }
    }
}
