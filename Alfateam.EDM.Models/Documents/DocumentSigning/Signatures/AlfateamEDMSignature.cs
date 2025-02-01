using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Documents.DocumentSigning.Signatures
{
    public class AlfateamEDMSignature : Signature
    {
        public string PublicKey { get; set; }
        public byte[] Signature { get; set; }
    }
}
