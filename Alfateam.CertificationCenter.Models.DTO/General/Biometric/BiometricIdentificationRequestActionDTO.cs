using Alfateam.CertificationCenter.Models.General.Biometric;
using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CertificationCenter.Models.DTO.General.Biometric
{
    public class BiometricIdentificationRequestActionDTO : DTOModelAbs<BiometricIdentificationRequestAction>
    {
        [ForClientOnly]
        public BiometricIdentificationActionDTO Action { get; set; }

        [ForClientOnly]
        public double DurationInSeconds { get; set; }
    }
}
