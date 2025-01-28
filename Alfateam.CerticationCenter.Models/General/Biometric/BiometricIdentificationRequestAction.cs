using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CertificationCenter.Models.General.Biometric
{
    public class BiometricIdentificationRequestAction : AbsModel
    {
        public BiometricIdentificationAction Action { get; set; }
        public int ActionId { get; set; }



        public double DurationInSeconds { get; set; }
    }
}
