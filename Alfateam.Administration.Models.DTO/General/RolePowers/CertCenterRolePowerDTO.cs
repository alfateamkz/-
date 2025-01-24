using Alfateam.Administration.Models.DTO.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Administration.Models.DTO.General.RolePowers
{
    public class CertCenterRolePowerDTO : RolePowerDTO
    {
        public bool CanSeeRequests { get; set; }
        public bool CanVerifyEDSRequests { get; set; }
        public bool CanVerifyDigitalPOARequests { get; set; }
    }
}
