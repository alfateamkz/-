using Alfateam.Core;
using Alfateam.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CertificationCenter.Models.General.Biometric
{
    public class SentBiometricIdentification : AbsModel
    {
        public BiometricIdentificationRequest IdentificationRequest { get; set; }
        public string IdentificationRequestId { get; set; }



        public UploadedFile Video { get; set; }
        public string VideoId { get; set; }
    }
}
