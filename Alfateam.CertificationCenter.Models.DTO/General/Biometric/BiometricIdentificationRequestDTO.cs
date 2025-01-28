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
    public class BiometricIdentificationRequestDTO : DTOModelAbsGuid<BiometricIdentificationRequest>
    {
        [ForClientOnly]
        public List<BiometricIdentificationRequestActionDTO> RandomActions { get; set; } = new List<BiometricIdentificationRequestActionDTO>();

        [ForClientOnly]
        public DateTime ExpiresAt { get; set; }
    }
}
