using Alfateam.EDM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Documents.DocumentSigning.Signatures
{
    public class ScanSignatureWithoutDocFlow : Signature
    {
        public string ScanPath { get; set; }
    }
}
