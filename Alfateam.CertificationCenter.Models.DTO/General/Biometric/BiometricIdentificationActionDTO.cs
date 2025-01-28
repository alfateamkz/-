using Alfateam.CertificationCenter.Models.General.Biometric;
using Alfateam.Website.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CertificationCenter.Models.DTO.General.Biometric
{
    public class BiometricIdentificationActionDTO : DTOModelAbs<BiometricIdentificationAction>
    {
        public string Title { get; set; }
    }
}
