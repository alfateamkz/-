using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Documents.Meta.Fields
{
    public class DocumentMetadataDateField : DocumentMetadataField
    {
        public DateTime Value { get; set; }
    }
}
