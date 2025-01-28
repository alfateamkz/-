using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CertificationCenter.Models.General.Biometric
{
    public class BiometricIdentificationRequest : AbsModelGuid
    {
        public List<BiometricIdentificationRequestAction> RandomActions { get; set; } = new List<BiometricIdentificationRequestAction>();
        public DateTime ExpiresAt { get; set; } = DateTime.UtcNow.AddMinutes(3);
    }
}
