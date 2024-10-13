using Alfateam.Core;
using Alfateam.EDM.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Documents.Types.Items
{
    public class PriceListItem : AbsModel
    {
        public string Barcode { get; set; }
        public string Title { get; set; }
        public string SKU { get; set; }
        public double PriceWithoutVAT { get; set; }
        public TaxSumInfo VAT { get; set; }
        public string MeasureUnit { get; set; }
    }
}
