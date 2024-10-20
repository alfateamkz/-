using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class DocTypeRelatedTo : Attribute
    {
        public readonly Type TypeOfDocTypeMetadata;
        public DocTypeRelatedTo(Type typeOfDocTypeMetadata)
        {
            TypeOfDocTypeMetadata = typeOfDocTypeMetadata;
        }
    }
}
