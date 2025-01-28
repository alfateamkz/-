using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Pkcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CertGenerators.Models
{
    public class GenerateCertificateInfo
    {
        public AlfateamEDSGeneratorPhysicalParams Props { get; set; } 


        public AsymmetricCipherKeyPair KeyPair { get; set; }
        public Pkcs10CertificationRequest CSR { get; set; }
        public X509Certificate2 PFX { get; set; }
    }
}
