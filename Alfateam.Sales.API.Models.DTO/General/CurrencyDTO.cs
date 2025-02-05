using Alfateam.Sales.Models.General;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Sales.API.Models.DTO.General
{
    public class CurrencyDTO : DTOModelAbs<Currency>
    {
        public string Title { get; set; }
        public string CurrencyCode { get; set; }
        public string Symbol { get; set; }
    }
}
