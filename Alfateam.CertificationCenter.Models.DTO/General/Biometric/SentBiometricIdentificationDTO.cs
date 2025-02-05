using Alfateam.CertificationCenter.Models.General.Biometric;
using Alfateam.Core.Attributes.DTO;
using Alfateam.SharedModels;
using Alfateam.Website.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CertificationCenter.Models.DTO.General.Biometric
{
    public class SentBiometricIdentificationDTO : DTOModelAbs<SentBiometricIdentification>
    {
        [ForClientOnly]
        public BiometricIdentificationRequestDTO IdentificationRequest { get; set; }

        [HiddenFromClient]
        public string IdentificationRequestId { get; set; }



        [ForClientOnly]
        public UploadedFile Video { get; set; }

        [HiddenFromClient]
        public string VideoId { get; set; }
    }
}
