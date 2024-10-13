using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.Documents.Types.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Documents.Types
{
    public class PriceListDocument : FormalizedElectronicDocument
    {
        public string SupplyAgreementNumber { get; set; }
        public DateTime SupplyAgreementDate { get; set; }


        public DateTime PricesStartsFrom { get; set; }
        public DateTime PricesActualBefore { get; set; }

        public List<PriceListItem> Items { get; set; } = new List<PriceListItem>();
    }
}
