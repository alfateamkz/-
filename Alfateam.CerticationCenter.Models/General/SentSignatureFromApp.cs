using Alfateam.CertificationCenter.Models.Enums;
using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CertificationCenter.Models.General
{
    public class SentSignatureFromApp : AbsModel
    {
        public string ReturnParameter { get; set; }
        public string PublicKey { get; set; }
        public EDSSignedType EDSType { get; set; }
        public byte[] Signature { get; set; }
    }
}
