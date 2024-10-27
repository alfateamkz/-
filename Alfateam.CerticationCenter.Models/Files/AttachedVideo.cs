using Alfateam.CertificationCenter.Models.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CertificationCenter.Models.Files
{
    public class AttachedVideo : AbsAttachedFile
    {
        public string RequirementsForVideo { get; set; }
    }
}
