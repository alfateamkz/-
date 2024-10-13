using Alfateam.Core;
using Alfateam.EDM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Documents
{
    public class DocumentReadEntry : AbsModel
    {
        public DocumentSigningSide ReadBy { get; set; }
        public int ReadById { get; set; }
    }
}
