using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CertGenerators.Attributes
{
    public class DerObjectIdentifierName : Attribute
    {
        public readonly string Name;
        public DerObjectIdentifierName(string name)
        {
            Name = name;
        }
    }
}
