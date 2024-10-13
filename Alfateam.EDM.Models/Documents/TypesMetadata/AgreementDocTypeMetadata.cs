using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Documents.TypesMetadata
{
    public class AgreementDocTypeMetadata : DocTypeMetadata
    {
        public string? AgreementType { get; set; }

        public string CurrencyCode { get; set; }

        public double SumWithoutVAT { get; set; }
        public TaxSumInfo VAT { get; set; }
    }
}
