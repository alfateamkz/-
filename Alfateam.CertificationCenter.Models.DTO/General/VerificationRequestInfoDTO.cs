using Alfateam.CertificationCenter.Models.Enums;
using Alfateam.CertificationCenter.Models.General;
using Alfateam.Website.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CertificationCenter.Models.DTO.General
{
    public class VerificationRequestInfoDTO : DTOModelAbs<VerificationRequestInfo>
    {
        public VerificationRequestStatus Status { get; set; }
        public string? Comment { get; set; }
    }
}
