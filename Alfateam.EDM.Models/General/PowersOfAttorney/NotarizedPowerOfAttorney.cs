using Alfateam.EDM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.General.PowersOfAttorney
{
    public class NotarizedPowerOfAttorney : PowerOfAttorney
    {
        public string NotaryInfo { get; set; }
        public string Filepath { get; set; }
    }
}
