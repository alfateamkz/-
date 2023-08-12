using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Promocodes;

namespace Alfateam.Website.API.Models.ClientModels
{
    public class PromocodeClientModel : ClientModel
    {
        public string Promocode { get; set; }
        public PromocodeType Type { get; set; }

        public Currency Currency { get; set; }
        public double? Value { get; set; }
        public double? PriceFrom { get; set; }
        public double? PriceTo { get; set; }

        public static PromocodeClientModel Create(Promocode item, int? countryId,int currencyId)
        {
            var model = new PromocodeClientModel();

            model.Id = item.Id;
            model.Promocode = item.Code;
            model.Type = item.Type;

            model.PriceFrom = item.PriceFrom.GetPrice(countryId, currencyId)?.Value;
            model.PriceTo = item.PriceTo.GetPrice(countryId, currencyId)?.Value;

            if (item is PercentPromocode percent)
            {
                model.Value = percent.Percent;
            }
            else if(item is PricePromocode pricePromocode)
            {
                model.Value = pricePromocode.Discount.GetPrice(countryId, currencyId)?.Value;
            }

            return model;        
        }
        public static List<PromocodeClientModel> CreateItems(IEnumerable<Promocode> items, int? langId, int currencyId)
        {
            var models = new List<PromocodeClientModel>();
            foreach (var item in items)
            {
                models.Add(Create(item, langId, currencyId));
            }
            return models;
        }
    }
}
