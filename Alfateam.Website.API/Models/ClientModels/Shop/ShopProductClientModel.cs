using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.ContentItems;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Shop;
using Alfateam2._0.Models.Shop.Modifiers;

namespace Alfateam.Website.API.Models.ClientModels.Shop
{
    public class ShopProductClientModel : ClientModel
    {
        public string Title { get; set; }
        public string Description { get; set; }


        public ShopProductCategoryClientModel Category { get; set; }


        /// <summary>
        /// Стоимость без учета модификаторов
        /// </summary>
        public List<Cost> BasePrices { get; set; } = new List<Cost>();
        public List<ProductModifierClientModel> Modifiers { get; set; } = new List<ProductModifierClientModel>();

        public ShopProductImage MainImage { get; set; }
        public List<ShopProductImage> Images { get; set; } = new List<ShopProductImage>();


        public static ShopProductClientModel Create(ShopProduct item, int? langId,int? countryId)
        {

            var model = new ShopProductClientModel();

            model.Id = item.Id;
            model.Title = item.Title;
            model.Description = item.Description;
            model.MainImage = item.MainImage;
            model.Images = item.Images;

            model.BasePrices = GetLocalCosts(item.BasePricing, countryId);

            if (item.MainLanguageId != langId)
            {
                var localization = item.Localizations.FirstOrDefault(o => o.LanguageId == langId);
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

            model.Category = ShopProductCategoryClientModel.Create(item.Category, langId);
            model.Modifiers = ProductModifierClientModel.CreateItems(item.Modifiers, langId, countryId);

            return model;
        }
        public static List<ShopProductClientModel> CreateItems(List<ShopProduct> items, int? langId, int? countryId)
        {
            var models = new List<ShopProductClientModel>();
            foreach (var item in items)
            {
                models.Add(Create(item, langId, countryId));
            }
            return models;
        }



       

    }
}
