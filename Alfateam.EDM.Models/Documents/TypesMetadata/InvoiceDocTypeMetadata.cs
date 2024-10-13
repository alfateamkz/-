using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Documents.TypesMetadata
{
    public class InvoiceDocTypeMetadata : DocTypeMetadata
    {
        public string CurrencyCode { get; set; }

        public double SumWithoutVAT { get; set; }
        public TaxSumInfo VAT { get; set; }


        public string? Reason { get; set; }
    }
}
