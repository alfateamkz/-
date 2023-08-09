using Alfateam.Models.Helpers;
using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Shop;

namespace Alfateam.Website.API.Models.ClientModels.Shop
{
    public class ShopProductCategoryClientModel : ClientModel
    {
        public string Title { get; set; }

        public string Slug => SlugHelper.GetLatynSlug(Title);

        public static ShopProductCategoryClientModel Create(ShopProductCategory item, int? langId)
        {

            var model = new ShopProductCategoryClientModel();

            model.Id = item.Id;
            model.Title = item.Title;

            if (item.MainLanguageId != langId)
            {
                var localization = item.Localizations.FirstOrDefault(o => o.LanguageId == langId);
                if (localization != null)
                {
                    model.Title = GetActualValue(model.Title, localization.Title);
                }
            }

            return model;
        }
        public static List<ShopProductCategoryClientModel> CreateItems(IEnumerable<ShopProductCategory> items, int? langId)
        {
            var models = new List<ShopProductCategoryClientModel>();
            foreach (var item in items)
            {
                models.Add(Create(item, langId));
            }
            return models;
        }
    }
}
