using Alfateam.CertificationCenter.Models.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CertificationCenter.Models.Files
{
    public class AttachedImage : AbsAttachedFile
    {
        public string RequirementsForImage { get; set; }
    }
}
