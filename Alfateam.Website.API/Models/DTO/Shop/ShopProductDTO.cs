using Alfateam.Models.Helpers;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Models.DTO.General;
using Alfateam2._0.Models.Shop;

namespace Alfateam.Website.API.Models.DTO.Shop
{
    public class ShopProductDTO : AvailabilityDTOModel<ShopProduct>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string SKU { get; set; }
        public string Slug => SlugHelper.GetLatynSlug(Title);



        public ShopProductCategoryDTO Category { get; set; }
        public int CategoryId { get; set; }


        /// <summary>
        /// Стоимость без учета модификаторов
        /// </summary>
        public List<CostDTO> BasePrices { get; set; } = new List<CostDTO>();
        public List<ProductModifierDTO> Modifiers { get; set; } = new List<ProductModifierDTO>();

        public ShopProductImage MainImage { get; set; }
        public List<ShopProductImage> Images { get; set; } = new List<ShopProductImage>();



        public int MainLanguageId { get; set; }



        public static ShopProductDTO Create(ShopProduct item, int? langId, int? countryId)
        {

            var model = new ShopProductDTO();

            model.Id = item.Id;
            model.Title = item.Title;
            model.Description = item.Description;
            model.MainImage = item.MainImage;
            model.Images = item.Images;

            var prices = GetLocalCosts(item.BasePricing, countryId);
            model.BasePrices = new CostDTO().CreateDTOsWithLocalization(prices, langId).Cast<CostDTO>().ToList();

            if (item.MainLanguageId != langId)
            {
                var localization = item.Localizations.FirstOrDefault(o => o.LanguageEntityId == langId);
                if (localization != null)
                {
                    model.Title = GetActualValue(model.Title, localization.Title);
                    model.Description = GetActualValue(model.Description, localization.Description);
                    model.MainImage = GetActualValue(model.MainImage, localization.MainImage) as ShopProductImage;


                    if (localization.UseLocalizationImages && localization.Images.Any())
                    {
                        model.Images = localization.Images;
                    }
                }
            }

            model.Category = new ShopProductCategoryDTO().CreateDTOWithLocalization(item.Category, langId) as ShopProductCategoryDTO;
            model.Modifiers = ProductModifierDTO.CreateItems(item.Modifiers, langId, countryId);

            return model;
        }
        public static List<ShopProductDTO> CreateItems(IEnumerable<ShopProduct> items, int? langId, int? countryId)
        {
            var models = new List<ShopProductDTO>();
            foreach (var item in items)
            {
                models.Add(Create(item, langId, countryId));
            }
            return models;
        }
    }
}
