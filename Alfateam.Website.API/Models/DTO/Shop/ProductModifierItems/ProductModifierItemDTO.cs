using Alfateam.Website.API.Abstractions;
using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Models.DTO.General;
using Alfateam.Website.API.Models.DTO.Promocodes;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Shop.Modifiers;
using JsonKnownTypes;
using Newtonsoft.Json;

namespace Alfateam.Website.API.Models.DTO.Shop.ProductModifierItems
{

    [JsonConverter(typeof(JsonKnownTypesConverter<ProductModifierItemDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(ColorModifierItemDTO), "ColorModifierItem")]
    [JsonKnownType(typeof(SimpleModifierItemDTO), "SimpleModifierItem")]
    public class ProductModifierItemDTO : DTOModel<ProductModifierItem>
    {
        [JsonProperty("discriminator")]
        public virtual string Discriminator { get; set; } = "ColorModifierItem";

        public string Title { get; set; }

        [ForClientOnly]
        public List<CostDTO> Costs { get; set; } = new List<CostDTO>();

        [ForClientOnly]
        public CostDTO Cost { get; set; }



        public PricingMatrixDTO Pricing { get; set; }


        public int MainLanguageId { get; set; }


        [DTOFieldFor(DTOFieldForType.CreationOnly)]
        public int ProductModifierId { get; set; }





        public ProductModifierItemDTO CreateDTOWithLocalization(ProductModifierItem item, int langId, int countryId, int currencyId)
        {
            var dto = (ProductModifierItemDTO)this.CreateDTOWithLocalization(item, langId);

            var costs = GetLocalCosts(item.Pricing, countryId);
            var cost = costs.FirstOrDefault(o => o.CurrencyId == currencyId);

            if (cost != null)
            {
                Cost = (CostDTO)new CostDTO().CreateDTOWithLocalization(cost, langId);
            }

            return dto;
        }
        public List<ProductModifierItemDTO> CreateDTOsWithLocalization(List<ProductModifierItem> items, int langId, int countryId, int currencyId)
        {
            var models = new List<ProductModifierItemDTO>();
            foreach (var item in items)
            {
                models.Add(CreateDTOWithLocalization(item, langId, countryId, currencyId));
            }
            return models;
        }
    }
}
