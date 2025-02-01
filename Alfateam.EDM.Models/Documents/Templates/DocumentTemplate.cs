using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alfateam.Core;
using Alfateam.EDM.Models.Abstractions;

namespace Alfateam.EDM.Models.Documents.Templates
{
    public class DocumentTemplate : AbsModel
    {
        public string Title { get; set; }

        public DocumentType DocumentType { get; set; }
        public int DocumentTypeId { get; set; }


        public UploadedFile DocumentFile { get; set; }
        public string DocumentFileId { get; set; }


        public List<DocumentTemplatePlaceholder> Placeholders { get; set; } = new List<DocumentTemplatePlaceholder>();



        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int EDMSubjectId { get; set; }
    }
}
