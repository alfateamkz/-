using Alfateam.Core;
using Alfateam.EDM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Documents
{
    public class DocumentStorageFile : AbsModel
    {
        public string Title { get; set; }
        public string? DocumentNumber { get; set; }
        public DateTime DocumentDate { get; set; }

        public DocumentType Type { get; set; }
        public int TypeId { get; set; }




        public UploadedFile File { get; set; }
        public string FileId { get; set; }

        public List<DocumentSigningSide> SigningSides { get; set; } = new List<DocumentSigningSide>();


        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int EDMSubjectId { get; set; }
    }
}
