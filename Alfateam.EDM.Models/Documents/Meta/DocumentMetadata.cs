using Alfateam.Core;
using Alfateam.EDM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Documents.Meta
{
    public class DocumentMetadata : AbsModel
    {
        public string DocumentNumber { get; set; }
        public DateTime DocumentDate { get; set; }
        public string? Comment { get; set; }


        public List<DocumentMetadataField> Fields { get; set; } = new List<DocumentMetadataField>();
    }
}
