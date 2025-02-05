using Alfateam.EDM.Models.Enums;
using Alfateam.EDM.Models.General;
using Alfateam.Website.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.API.Models.DTO.General
{
    public class PowerOfAttorneyVerificationInfoDTO : DTOModelAbs<PowerOfAttorneyVerificationInfo>
    {
        public PowerOfAttorneyVerificationStatus Status { get; set; }
        public string? Comment { get; set; }
    }
}
