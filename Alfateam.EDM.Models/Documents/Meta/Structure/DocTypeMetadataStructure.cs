using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Documents.Meta.Structure
{
    public class DocTypeMetadataStructure : AbsModel
    {
        public List<DocTypeMetadataStructureField> Fields { get; set; } = new List<DocTypeMetadataStructureField>();
    }
}
