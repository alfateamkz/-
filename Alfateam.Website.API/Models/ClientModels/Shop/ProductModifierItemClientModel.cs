using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Models.ClientModels.General;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Shop.Modifiers;

namespace Alfateam.Website.API.Models.ClientModels.Shop
{
    public class ProductModifierItemClientModel : ClientModel
    {
        public string Title { get; set; }
        public List<CostClientModel> Costs { get; set; } = new List<CostClientModel>();

        public static ProductModifierItemClientModel Create(ProductModifierItem item, int? langId, int? countryId)
        {

            var model = new ProductModifierItemClientModel();

            model.Id = item.Id;
            model.Title = item.Title;

            var costs = GetLocalCosts(item.Pricing, countryId);
            model.Costs = CostClientModel.CreateItems(costs,langId);

            if (item.MainLanguageId != langId)
            {
                var localization = item.Localizations.FirstOrDefault(o => o.LanguageEntityId == langId);
                if (localization != null)
                {
                    model.Title = GetActualValue(model.Title, localization.Title);
                }
            }

            return model;
        }
        public static List<ProductModifierItemClientModel> CreateItems(List<ProductModifierItem> items, int? langId, int? countryId)
        {
            var models = new List<ProductModifierItemClientModel>();
            foreach (var item in items)
            {
                models.Add(Create(item, langId, countryId));
            }
            return models;
        }
    }
}
