using Alfateam.EDM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Documents.DocumentSigning.Signatures
{
    public class MarkedAsElectronicallySignature : Signature
    {
        public EDMProvider EDMProvider { get; set; }
        public int EDMProviderId { get; set; }
    }
}
