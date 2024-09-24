using Alfateam.Core;
using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.General
{
    /// <summary>
    /// Матрица цен по странам
    /// </summary>
    public class PricingMatrix : AbsModel
    {
        public List<PricingMatrixItem> Costs { get; set; } = new List<PricingMatrixItem>();

        public List<Cost> GetLocalCosts(int? countryId)
        {
            PricingMatrixItem found = null;

            if (countryId != null)
            {
                found = this.Costs.FirstOrDefault(o => o.CountryId == countryId);
                if (found != null) return found.Costs;
            }

            found = this.Costs.FirstOrDefault(o => o.CountryId == null);
            if (found != null) return found.Costs;

            found = this.Costs.FirstOrDefault(o => o.Costs.Any(o => o.Currency.Code == "USD"));
            if (found != null) return found.Costs;

            found = this.Costs.FirstOrDefault(o => o.Costs.Any(o => o.Currency.Code == "EUR"));
            if (found != null) return found.Costs;

            found = this.Costs.FirstOrDefault();
            return found.Costs;

        }

        public Cost? GetPrice(int? countryId,int currencyId)
        {
            PricingMatrixItem countryItem = null;

            if(countryId != null)
            {
                countryItem = Costs.FirstOrDefault(o => o.CountryId == countryId
                                  && o.Costs.Any(o => o.CurrencyId == currencyId));
            }


            if (countryItem == null)
            {
                countryItem = Costs.FirstOrDefault(o => o.CountryId == null
                                  && o.Costs.Any(o => o.CurrencyId == currencyId));

                if (countryItem == null)
                {
                    countryItem = Costs.FirstOrDefault(o => o.Costs.Any(o => o.CurrencyId == currencyId));
                }
            }


            if (countryItem != null)
            {
                return countryItem.Costs.FirstOrDefault(o => o.CurrencyId == currencyId);
            }
            return null;
        }
    }
}
