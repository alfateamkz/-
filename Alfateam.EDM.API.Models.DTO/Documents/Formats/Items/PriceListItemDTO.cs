using Alfateam.EDM.API.Models.DTO.General;
using Alfateam.EDM.Models.Documents.Types.Items;
using Alfateam.EDM.Models.General;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.EDM.API.Models.DTO.Documents.Types.Items
{
    public class PriceListItemDTO : DTOModelAbs<PriceListItem>
    {
        public string Barcode { get; set; }
        public string Title { get; set; }
        public string SKU { get; set; }
        public double PriceWithoutVAT { get; set; }
        public TaxSumInfoDTO VAT { get; set; }
        public string MeasureUnit { get; set; }
    }
}
