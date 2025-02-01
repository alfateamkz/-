using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.Documents.DocumentSigning;
using Alfateam.EDM.Models.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alfateam.Core;
using Alfateam.EDM.Models.Documents.Meta;
using Alfateam.EDM.Models.Enums;
using Alfateam.EDM.Models.Documents.Meta.Fields;

namespace Alfateam.EDM.Models.Documents.Types
{

    public class DocumentWithFile : Document
    {
        public UploadedFile File { get; set; }
        public string FileId { get; set; }




    
    }
}
