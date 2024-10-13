using Alfateam.EDM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Documents.TypesMetadata
{
    public class ClaimDocTypeMetadata : DocTypeMetadata
    {
        public string CurrencyCode { get; set; }
        public double Sum { get; set; }
    }
}
