using Alfateam.DB;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Shop;
using Alfateam2._0.Models.Shop.Modifiers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Alfateam.Website.API.Extensions
{
    public static class DBSetExtensions
    {
        public static IIncludableQueryable<T, List<Country>> IncludeAvailability<T>(this IQueryable<T> dbset) where T : AvailabilityModel
        {
            return dbset.Include(o => o.Availability).ThenInclude(o => o.AllowedCountries)
                        .Include(o => o.Availability).ThenInclude(o => o.DisallowedCountries);
        }

        public static IIncludableQueryable<ShopProduct, Country> IncludePricing(this IQueryable<ShopProduct> dbset)
        {
            var res = dbset.Include(o => o.BasePricing).ThenInclude(o => o.Costs).ThenInclude(o => o.Costs).ThenInclude(o => o.Currency)
                           .Include(o => o.BasePricing).ThenInclude(o => o.Costs).ThenInclude(o => o.Country);
            return res;
        }


    }
}
