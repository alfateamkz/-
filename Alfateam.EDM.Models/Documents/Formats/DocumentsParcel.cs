using Alfateam.EDM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Documents.Formats
{
    public sealed class DocumentsParcel : Document
    {
        public List<Document> Documents { get; set; } = new List<Document>();
    }
}
