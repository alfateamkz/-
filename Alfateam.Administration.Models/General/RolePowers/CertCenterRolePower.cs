using Alfateam.Administration.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Administration.Models.General.RolePowers
{
    public class CertCenterRolePower : RolePower
    {
        public bool CanSeeRequests { get; set; }
        public bool CanVerifyEDSRequests { get; set; }
        public bool CanVerifyDigitalPOARequests { get; set; }
    }
}
