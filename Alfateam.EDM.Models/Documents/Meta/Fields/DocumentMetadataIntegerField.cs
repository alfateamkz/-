using Alfateam.EDM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Documents.Meta.Fields
{
    public class DocumentMetadataIntegerField : DocumentMetadataField
    {
        public int Value { get; set; }
    }
}
