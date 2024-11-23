using Alfateam.DB.ServicesDBs;
using Alfateam.Sales.Models.General;
using Alfateam.Sales.Models.Orders;

namespace Alfateam.Sales.API.Helpers
{
    public static class ConversionHelper
    {
        public static double GetOrdersSum(CurrencyRatesDbContext currencyDB, Currency mainCurrency, IEnumerable<Order> orders)
        {
            double sum = 0;

            foreach(var order in orders)
            {
                if(order.Sum.Currency.CurrencyCode == mainCurrency.CurrencyCode)
                {
                    sum += order.Sum.Value;
                }
                else
                {
                    sum += currencyDB.GetRate(order.Sum.Currency.CurrencyCode, mainCurrency.CurrencyCode);
                }
            }

            return sum;
        }
    }
}
