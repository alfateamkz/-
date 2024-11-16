using Alfateam.Sales.Models.General;

namespace Alfateam.Sales.API.Models
{
    public class CurrencyAmountAndSum
    {
        public Currency Currency { get; set; }
        public double Amount { get; set; }
        public double Sum { get; set; }
    }
}
