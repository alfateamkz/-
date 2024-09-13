using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Attributes.DTO;
using Alfateam.Website.API.Models.DTO.Promocodes;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Promocodes;
using JsonKnownTypes;
using Newtonsoft.Json;

namespace Alfateam.Website.API.Models.DTO.Promocodes
{
    [JsonConverter(typeof(JsonKnownTypesConverter<PromocodeDTO>))]
    [JsonDiscriminator(Name = "Discriminator")]
    [JsonKnownType(typeof(PricePromocodeDTO), "PricePromocode")]
    [JsonKnownType(typeof(PercentPromocodeDTO), "PercentPromocode")]
    public class PromocodeDTO : DTOModel<Promocode>
    {
        public virtual string Discriminator { get; }



        public string Promocode { get; set; }
        public PromocodeType Type { get; set; }

        public Currency Currency { get; set; }
        public double? Value { get; set; }
        public double? PriceFrom { get; set; }
        public double? PriceTo { get; set; }




        #region Для админа
        public string Code { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public bool IsReusable { get; set; }


        public PricingMatrix? PriceFromMatrix { get; set; }
        public PricingMatrix? PriceToMatrix { get; set; }
        #endregion



        public static PromocodeDTO Create(Promocode item, int? countryId, int currencyId)
        {
            var model = new PromocodeDTO();

            model.Id = item.Id;
            model.Promocode = item.Code;
            model.Type = item.Type;

            model.PriceFrom = item.PriceFrom.GetPrice(countryId, currencyId)?.Value;
            model.PriceTo = item.PriceTo.GetPrice(countryId, currencyId)?.Value;

            if (item is PercentPromocode percent)
            {
                model.Value = percent.Percent;
            }
            else if (item is PricePromocode pricePromocode)
            {
                model.Value = pricePromocode.Discount.GetPrice(countryId, currencyId)?.Value;
            }

            return model;
        }
        public static List<PromocodeDTO> CreateItems(IEnumerable<Promocode> items, int? langId, int currencyId)
        {
            var models = new List<PromocodeDTO>();
            foreach (var item in items)
            {
                models.Add(Create(item, langId, currencyId));
            }
            return models;
        }
    }
}
