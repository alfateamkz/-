using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.Documents.Types.Items;
using Alfateam.EDM.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Documents.Types
{
    public class WithPositionItemsDocument : FormalizedElectronicDocument
    {
        public WithPositionItemsDocumentType Type { get; set; } 

        public string? Description { get; set; }
        public string? Comment { get; set; }


        public string CurrencyCode { get; set; }
        public List<DocumentPositionItem> Items { get; set; } = new();
        



        [NotMapped]
        public double TotalVAT => Items.Sum(o => o.VAT.GetTaxSum(o.PriceForOne, o.Quantity));
        [NotMapped]
        public double TotalExcise => Items.Sum(o => o.Excise.GetTaxSum(o.PriceForOne, o.Quantity));
        [NotMapped]
        public double TotalSum => Items.Sum(o => o.TotalSum);

    }
}
