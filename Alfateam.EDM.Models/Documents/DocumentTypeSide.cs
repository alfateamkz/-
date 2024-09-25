using Alfateam.EDM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alfateam.Core;

namespace Alfateam.EDM.Models.Documents
{
    public class DocumentTypeSide : AbsModel
    {
        public string Title { get; set; }
        public bool IsSignatureRequired { get; set; }
    }
}
