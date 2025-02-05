using Alfateam.Core;
using Alfateam.EDM.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.General
{
    public class PowerOfAttorneyVerificationInfo : AbsModel
    {
        public PowerOfAttorneyVerificationStatus Status { get; set; } = PowerOfAttorneyVerificationStatus.Waiting;
        public string? Comment { get; set; }
    }
}
