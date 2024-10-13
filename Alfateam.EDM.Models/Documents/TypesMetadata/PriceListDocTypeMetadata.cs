using Alfateam.EDM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Documents.TypesMetadata
{
    public class PriceListDocTypeMetadata : DocTypeMetadata
    {
        public string ToAgreementNumber { get; set; }
        public DateTime ToAgreementDate { get; set; }


        public DateTime PricesStartsFrom { get; set; }
        public DateTime PricesActualBefore { get; set; }
    }
}
