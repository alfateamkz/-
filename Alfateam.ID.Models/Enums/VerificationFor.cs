using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.ID.Models.Enums
{
    public enum VerificationFor
    {
        ContactVerification = 1,
        ContactChangeVerification = 2,
        Auth = 3,


        CertCenter_DigitalPOACancellation = 101,
        CertCenter_AlfateamEDSCancellation = 102,
    }
}
