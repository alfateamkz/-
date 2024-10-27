using Alfateam.CertificationCenter.Models.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CertificationCenter.Models.Cancellation
{
    public class EDSCancellationRequest : CancellationRequest
    {
        public AlfateamEDS EDSToCancel { get; set; }
    }
}
