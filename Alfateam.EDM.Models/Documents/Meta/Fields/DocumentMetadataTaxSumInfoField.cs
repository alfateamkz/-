using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Documents.Meta.Fields
{
    public class DocumentMetadataTaxSumInfoField : DocumentMetadataField
    {
        public TaxSumInfo Value { get; set; }
    }
}
