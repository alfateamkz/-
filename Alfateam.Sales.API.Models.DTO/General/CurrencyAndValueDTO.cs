using Alfateam.Core.Attributes.DTO;
using Alfateam.Sales.Models.General;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Sales.API.Models.DTO.General
{
    public class CurrencyAndValueDTO : DTOModelAbs<CurrencyAndValue>
    {


        [ForClientOnly]
        public CurrencyDTO Currency { get; set; }
        [HiddenFromClient]
        public int CurrencyId { get; set; }


        public double Value { get; set; }
    }
}
