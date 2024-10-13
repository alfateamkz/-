using Alfateam.Core;
using Alfateam.EDM.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.General
{
    public class TaxSumInfo : AbsModel
    {
        public bool HasTax { get; set; }
        public TaxMeasureType MeasureType { get; set; } = TaxMeasureType.Percent;
        public double Value { get; set; }


        public double GetTaxSum(double priceForOne, double quantity)
        {
            if(HasTax)
            {
                switch (MeasureType)
                {
                    case TaxMeasureType.Percent:
                        return priceForOne * quantity / 100 * Value;
                    case TaxMeasureType.Sum:
                        return Value;
                }
            }
            return 0;
        }
    }
}
