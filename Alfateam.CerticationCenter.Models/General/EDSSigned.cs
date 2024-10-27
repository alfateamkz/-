using Alfateam.CertificationCenter.Models.Enums;
using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CertificationCenter.Models.General
{
    public class EDSSigned : AbsModel
    {
        public string EDSCountryCode { get; set; }  
        public EDSSignedType Type { get; set; }

        public string SignedHash { get; set; }
    }
}
