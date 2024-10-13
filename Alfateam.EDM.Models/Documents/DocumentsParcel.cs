using Alfateam.Core;
using Alfateam.EDM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Documents
{
    public class DocumentsParcel : AbsModel
    {

        public List<Document> Documents { get; set; } = new List<Document>();

    }
}
