using Alfateam.EDM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alfateam.Core;

namespace Alfateam.EDM.Models.Documents.DocumentSigning
{
    public class SignedDocumentRoamingInfo : AbsModel
    {
        public EDMProvider Provider { get; set; }
        public int ProviderId { get; set; }

    }

}
