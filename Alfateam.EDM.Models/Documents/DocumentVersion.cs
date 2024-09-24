using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.Documents.DocumentSigning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Documents
{
    /// <summary>
    /// Версия документа
    /// </summary>
    public class DocumentVersion : AbsModel
    {

        public int VersionNumber { get; set; }
        public string DocumentFilepath { get; set; }



        /// <summary>
        /// Статусы рассмотрения документа сторонами
        /// </summary>
        public List<DocumentVersionSideFeedback> Feedbacks { get; set; } = new List<DocumentVersionSideFeedback>();
        /// <summary>
        /// Комментарии сторон к документу
        /// </summary>
        public List<DocumentSigningSideComment> Comments { get; set; } = new List<DocumentSigningSideComment>();


        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int DocumentId { get; set; }

	}

}
