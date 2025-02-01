using Alfateam.EDM.API.Models.DTO.Abstractions;
using Alfateam.EDM.API.Models.DTO.Documents.Types.Items;
using Alfateam.EDM.Models.Documents.Types.Items;
using Alfateam.EDM.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alfateam.EDM.API.Models.DTO.Documents.Types
{
    public class WithPositionItemsDocumentDTO : FormalizedElectronicDocumentDTO
    {
        public WithPositionItemsDocumentType Type { get; set; }

        public string? Description { get; set; }
        public string? Comment { get; set; }


        public string CurrencyCode { get; set; }
        public List<DocumentPositionItemDTO> Items { get; set; } = new();



        public double TotalVAT => Items.Sum(o => o.VAT.GetTaxSum(o.PriceForOne, o.Quantity));
        public double TotalExcise => Items.Sum(o => o.Excise.GetTaxSum(o.PriceForOne, o.Quantity));
        public double TotalSum => Items.Sum(o => o.TotalSum);
    }
}
