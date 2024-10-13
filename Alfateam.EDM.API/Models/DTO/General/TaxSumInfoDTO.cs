using Alfateam.EDM.Models.Enums;
using Alfateam.EDM.Models.General;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.EDM.API.Models.DTO.General
{
    public class TaxSumInfoDTO : DTOModelAbs<TaxSumInfo>
    {
        public bool HasTax { get; set; }
        public TaxMeasureType MeasureType { get; set; }
        public double Value { get; set; }


        public double GetTaxSum(double priceForOne, double quantity)
        {
            if (HasTax)
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
