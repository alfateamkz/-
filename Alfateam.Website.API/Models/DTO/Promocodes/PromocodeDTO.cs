using Alfateam.Website.API.Abstractions;
using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Models.DTO.General;
using Alfateam.Website.API.Models.DTO.Promocodes;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Promocodes;
using JsonKnownTypes;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alfateam.Website.API.Models.DTO.Promocodes
{

    [JsonConverter(typeof(JsonKnownTypesConverter<PromocodeDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(PricePromocodeDTO), "PricePromocode")]
    [JsonKnownType(typeof(PercentPromocodeDTO), "PercentPromocode")]
    public class PromocodeDTO : AvailabilityDTOModel<Promocode>
    {
        [JsonProperty("discriminator")]
        public virtual string Discriminator { get; }


        public string Code { get; set; }
        public PromocodeType Type { get; set; }


        [ForClientOnly]
        public CurrencyDTO Currency { get; set; }
        public int CurrencyId { get; set; }


        public double? Value { get; set; }
        public double? PriceFromValue { get; set; }
        public double? PriceToValue { get; set; }




        #region Для админа
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public bool IsReusable { get; set; }


        public PricingMatrixDTO? PriceFrom { get; set; }
        public PricingMatrixDTO? PriceTo { get; set; }
        #endregion


        public int MainLanguageId { get; set; }

        public static PromocodeDTO Create(Promocode item, int? countryId, int currencyId)
        {
            var model = new PromocodeDTO();

            model.Id = item.Id;
            model.Code = item.Code;
            model.Type = item.Type;

            model.PriceFromValue = item.PriceFrom.GetPrice(countryId, currencyId)?.Value;
            model.PriceToValue = item.PriceTo.GetPrice(countryId, currencyId)?.Value;

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
