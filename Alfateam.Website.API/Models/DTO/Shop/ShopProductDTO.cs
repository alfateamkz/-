using Alfateam.Core.Helpers;
using Alfateam.Website.API.Abstractions;
using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Models.DTO.General;
using Alfateam.Website.API.Models.DTO.Outstaff;
using Alfateam2._0.Models.Outstaff;
using Alfateam2._0.Models.Shop;
using Swashbuckle.AspNetCore.Annotations;
using Alfateam2._0.Models.General;
using System.ComponentModel;

namespace Alfateam.Website.API.Models.DTO.Shop
{
    public class ShopProductDTO : AvailabilityDTOModel<ShopProduct>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string SKU { get; set; }
        public string Slug => SlugHelper.GetLatynSlug(Title);


        [ForClientOnly]
        public ShopProductCategoryDTO Category { get; set; }
        public int CategoryId { get; set; }




        /// <summary>
        /// Стоимость без учета модификаторов
        /// </summary>
        [Description("Цены для админки")]
        public PricingMatrixDTO BasePricing { get; set; }



        /// <summary>
        /// Стоимость без учета модификаторов
        /// </summary>
        [ForClientOnly]
        [Description("Цена для клиента, получаем, передавая заголовки CountryId и CurrencyId")]
        public CostDTO BasePrice { get; set; }

        [ForClientOnly]
        public List<ProductModifierDTO> Modifiers { get; set; } = new List<ProductModifierDTO>();


        [ForClientOnly]
        public ShopProductImage MainImage { get; set; }
        [ForClientOnly]
        public List<ShopProductImage> Images { get; set; } = new List<ShopProductImage>();



        public int MainLanguageId { get; set; }

        public ShopProductDTO CreateDTOWithLocalization(ShopProduct item, int langId, int countryId, int currencyId)
        {
            var dto = (ShopProductDTO)this.CreateDTOWithLocalization(item, langId);

            var prices = GetLocalCosts(item.BasePricing, countryId);
            var price = prices.FirstOrDefault(o => o.CurrencyId == currencyId);

            if (price != null)
            {
                BasePrice = (CostDTO)new CostDTO().CreateDTOWithLocalization(price, langId);
            }

            var localization = item.Localizations.FirstOrDefault(o => o.LanguageEntityId == langId);
            if (localization != null)
            {
                if (localization.UseLocalizationImages && localization.Images.Any())
                {
                    dto.Images = localization.Images;
                }
            }

            dto.Modifiers = new ProductModifierDTO().CreateDTOsWithLocalization(item.Modifiers, langId, countryId, currencyId);

            return dto;
        }
        public List<ShopProductDTO> CreateDTOsWithLocalization(List<ShopProduct> items, int langId, int countryId, int currencyId)
        {
            var models = new List<ShopProductDTO>();
            foreach (var item in items)
            {
                models.Add(CreateDTOWithLocalization(item, langId, countryId, currencyId));
            }
            return models;
        }

    }
}
