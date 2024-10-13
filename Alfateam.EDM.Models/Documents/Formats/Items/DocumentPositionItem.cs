using Alfateam.Core;
using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.Enums;
using Alfateam.EDM.Models.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Documents.Types.Items
{
    public class DocumentPositionItem : AbsModel
    {
        public string Title { get; set; }
        public string MeasureUnit { get; set; }
        public double PriceForOne { get; set; }
        public double Quantity { get; set; }

        [NotMapped]
        public double TotalSum => PriceForOne * Quantity;


        public TaxSumInfo VAT { get; set; }
        public TaxSumInfo Excise { get; set; }


        public List<DocumentPositionItemModifier> Modifiers { get; set; } = new List<DocumentPositionItemModifier>();

    }
}
