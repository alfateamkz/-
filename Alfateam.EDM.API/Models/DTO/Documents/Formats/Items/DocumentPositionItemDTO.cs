using Alfateam.EDM.API.Models.DTO.General;
using Alfateam.EDM.Models.Documents.Types.Items;
using Alfateam.EDM.Models.General;
using Alfateam.Website.API.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alfateam.EDM.API.Models.DTO.Documents.Types.Items
{
    public class DocumentPositionItemDTO : DTOModelAbs<DocumentPositionItem>
    {
        public string Title { get; set; }
        public string MeasureUnit { get; set; }
        public double PriceForOne { get; set; }
        public double Quantity { get; set; }

        [NotMapped]
        public double TotalSum => PriceForOne * Quantity;


        public TaxSumInfoDTO VAT { get; set; }
        public TaxSumInfoDTO Excise { get; set; }


        public List<DocumentPositionItemModifierDTO> Modifiers { get; set; } = new List<DocumentPositionItemModifierDTO>();
    }
}
