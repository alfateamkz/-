using Alfateam.EDM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Documents.TypesMetadata
{
    public class ActDisagreementDocTypeMetadata : DocTypeMetadata
    {

        public override string Title => "Акт разногласий";

        public double Sum { get; set; }
    }
}
